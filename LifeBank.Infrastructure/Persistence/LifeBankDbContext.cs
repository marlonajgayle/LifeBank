using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Common;
using LifeBank.Domain.Entities;
using LifeBank.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure.Persistence
{
    public class LifeBankDbContext : IdentityDbContext<ApplicationUser>, ILifeBankDbContext
    {
        public readonly ICurrentUserService currentUserService;

        public LifeBankDbContext(DbContextOptions<LifeBankDbContext> options)
            : base(options)
        {

        }

        public LifeBankDbContext(DbContextOptions<LifeBankDbContext> options,
            ICurrentUserService currentUserService)
        {
            CurrentUserService = currentUserService;
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Parish> Parishes { get; set; }

        public ICurrentUserService CurrentUserService { get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
