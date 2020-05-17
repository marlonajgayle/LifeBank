using LifeBank.Application.Common.Models;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface ISecurityTokenManager
    {
        Task<TokenResult> GenerateClaimsTokenAsync(long userId, string email, CancellationToken cancellationToken);

        Task<TokenResult> RefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken);

        ClaimsPrincipal GetPrincipFromToken(string token);
    }
}
