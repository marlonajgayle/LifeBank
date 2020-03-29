﻿using LifeBank.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, long>
    {
        private readonly LifeBankDbContext dbContext;

        public UpdateDonorCommandHandler(LifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<long> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            // check to see if donor exist
            var entity = await dbContext.Donors.FindAsync(request.DonorId);

            if (entity != null)
            {
                entity.FirstName = request.FirstName;
                entity.MiddleInital = request.MiddleInital;
                entity.LastName = request.LastName;
                entity.Gender = request.Gender;
                entity.DateOfBirth = request.DateOfBirth;
                entity.BloodType = request.BloodType;

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception();
            }

            return entity.DonorId;
        }
    }
}
