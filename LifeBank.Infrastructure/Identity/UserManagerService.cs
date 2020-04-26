using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> ChangePasswordAsync(object user, string currentPassword, string newPassword)
        {
            return await userManager.ChangePasswordAsync((ApplicationUser)user, currentPassword, newPassword);
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser()
            {
                UserName = userName,
                Email = userName
            };

            var result = await userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }
        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<IApplicationUser> FindUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<string> GeneratePasswordUserTokenAsync(object user)
        {
            return await userManager.GeneratePasswordResetTokenAsync((ApplicationUser)user);
        }

        public async Task<IApplicationUser> GetUserAsync(object user)
        {
            return await userManager.GetUserAsync((ClaimsPrincipal)user);
        }

        public async Task<Result> ResetPasswordAsync(object user, string token, string password)
        {
            var result = await userManager.ResetPasswordAsync((ApplicationUser)user, token, password);

            // TODO: send email with link and token

            return result.ToApplicationResult();
        }

        public async Task<bool> CheckPasswordAsync(object user, string password)
        {
            return await userManager.CheckPasswordAsync((ApplicationUser)user, password);
        }
    }
}
