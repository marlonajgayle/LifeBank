using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LifeBank.Infrastructure.Identity
{
    public class SecurityTokenManager : ISecurityTokenManager
    {
        private readonly JwtSettings jwtSettings;

        public SecurityTokenManager(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public TokenResult GenerateClaimsTokenAsync(long userId, string email)
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
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResult() { Token = tokenHandler.WriteToken(token) };
        }
    }
}
