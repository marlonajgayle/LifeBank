using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface ISignInManager
    {
        Task<SignInResult> LoginAsync(string userName, string password);

        Task<int> LogoutAsync();
    }
}
