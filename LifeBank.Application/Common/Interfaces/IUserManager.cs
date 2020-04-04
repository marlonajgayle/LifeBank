using LifeBank.Application.Common.Models;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
