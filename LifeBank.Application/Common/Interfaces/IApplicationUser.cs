using Microsoft.AspNetCore.Identity;

namespace LifeBank.Application.Common.Interfaces
{
    public class IApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DonorId { get; set; }
    }
}
