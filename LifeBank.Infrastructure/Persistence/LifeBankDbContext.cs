using LifeBank.Domain.Entities;
using LifeBank.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeBank.Infrastructure.Persistence
{
    public class LifeBankDbContext : IdentityDbContext<ApplicationUser>
    {
        public LifeBankDbContext(DbContextOptions<LifeBankDbContext> options)
            : base(options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donoations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
