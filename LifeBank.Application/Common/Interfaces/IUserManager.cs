using LifeBank.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<IApplicationUser> FindUserByEmailAsync(string email);

        Task<IApplicationUser> GetUserAsync(Object user);

        Task<IdentityResult> ChangePasswordAsync(Object user, string currentPassword, string newPassword);

        Task<String> GeneratePasswordUserTokenAsync(Object user);

        Task<Result> ResetPasswordAsync(object user, string token, string password);

        Task<bool> CheckPasswordAsync(object user, string password);

    }
}
