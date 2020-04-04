using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
