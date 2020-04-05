using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
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

        public async Task<object> FindUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<string> GeneratePasswordUserTokenAsync(object user)
        {
            return await userManager.GeneratePasswordResetTokenAsync((ApplicationUser)user);
        }
    }
}
