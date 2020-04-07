using LifeBank.Application.Common.Models;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IMailService
    {
        Task<string> SendAsync(MessageDto message);
    }
}
