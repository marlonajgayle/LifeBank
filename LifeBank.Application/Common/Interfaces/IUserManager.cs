using LifeBank.Application.Common.Models;
using System;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<Object> FindUserByEmailAsync(string email);

        Task<String> GeneratePasswordUserTokenAsync(Object user);

        Task<Result> ResetPasswordAsync(object user, string token, string password);
    }
}
