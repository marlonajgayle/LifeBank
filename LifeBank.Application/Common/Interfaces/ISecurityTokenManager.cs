using LifeBank.Application.Common.Models;

namespace LifeBank.Application.Common.Interfaces
{
    public interface ISecurityTokenManager
    {
        TokenResult GenerateClaimsTokenAsync(long userId, string email);
    }
}
