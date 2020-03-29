using AutoMapper;
using LifeBank.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, long>
    {
        private readonly LifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDonorCommandHandler(LifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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
                return 0;
            }

            return entity.DonorId;
        }
    }
}
