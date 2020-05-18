using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface ILifeBankDbContext
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Parish> Parishes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
