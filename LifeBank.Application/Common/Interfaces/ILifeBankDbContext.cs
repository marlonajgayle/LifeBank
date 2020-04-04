﻿using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Common.Interfaces
{
    public interface ILifeBankDbContext
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donoations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
