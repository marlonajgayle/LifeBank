using LifeBank.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure.Identity
{
    public class SignInManagerService : ISignInManager
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public SignInManagerService(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(string userName, string password)
        {
            var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

            return result;
        }

        public async void LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
