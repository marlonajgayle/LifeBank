using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure.Identity
{
    public class SecurityTokenManager : ISecurityTokenManager
    {
        private readonly JwtSettings jwtSettings;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly ILifeBankDbContext dbContext;
        private readonly IUserManager userManager;

        public SecurityTokenManager(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters,
            ILifeBankDbContext dbContext, IUserManager userManager)
        {
            this.jwtSettings = jwtSettings;
            this.tokenValidationParameters = tokenValidationParameters;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<TokenResult> GenerateClaimsTokenAsync(long userId, string email, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("id", userId.ToString())
                }),
                Expires = DateTime.UtcNow.Add(jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = userId,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(5)
            };

            dbContext.RefreshTokens.Add(refreshToken);
            await dbContext.SaveChangesAsync(cancellationToken);


            return new TokenResult()
            {
                Succeeded = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }

        public async Task<TokenResult> RefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken)
        {
            var validatedToken = GetPrincipFromToken(token);

            if (validatedToken == null)
            {
                return new TokenResult { Succeeded = false, Error = "Invalid token" };
            }

            var expirationDate = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expirationDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expirationDate);

            if (expirationDateTimeUtc > DateTime.UtcNow)
            {
                return new TokenResult { Succeeded = false, Error = "This token hasn't expired" };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshToken = await dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                return new TokenResult { Succeeded = false, Error = "This token does not exist" };
            }

            if (expirationDateTimeUtc > storedRefreshToken.ExpirationDate)
            {
                return new TokenResult { Succeeded = false, Error = "This refresh token has expired" };
            }

            if (storedRefreshToken.Invalidated)
            {
                return new TokenResult { Succeeded = false, Error = "This refresh token has been invalidated" };
            }

            if (storedRefreshToken.Used)
            {
                return new TokenResult { Succeeded = false, Error = "This refresh token has already been used" };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new TokenResult { Succeeded = false, Error = "This refresh token does not match this JWT" };
            }

            storedRefreshToken.Used = true;
            dbContext.RefreshTokens.Update(storedRefreshToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var user = await userManager.FindUserByEmailAsync(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            var tokenResult = await GenerateClaimsTokenAsync(user.DonorId, user.Email, cancellationToken);

            return tokenResult;
        }

        public ClaimsPrincipal GetPrincipFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}