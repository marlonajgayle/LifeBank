using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, long>
    {
        private readonly ILifeBankDbContext dbContext;

        public UpdateDonorCommandHandler(ILifeBankDbContext dbContext)
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
                entity.BloodTypeId = request.BloodTypeId;

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Donor), request.DonorId);
            }

            return entity.DonorId;
        }
    }
}
