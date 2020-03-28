using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeBank.Infrastructure.Persistence
{
    public class LifeBankDbContext : DbContext
    {
        public LifeBankDbContext(DbContextOptions<LifeBankDbContext> options)
            : base(options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donoations { get; set; }
    }
}
