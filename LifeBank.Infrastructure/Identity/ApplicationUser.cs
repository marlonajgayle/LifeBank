using Microsoft.AspNetCore.Identity;

namespace LifeBank.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DonorId { get; set; }
    }
}
