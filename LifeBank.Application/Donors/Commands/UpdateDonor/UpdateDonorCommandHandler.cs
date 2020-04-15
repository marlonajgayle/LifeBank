using AutoMapper;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, DonorViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDonorCommandHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DonorViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
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

            return mapper.Map<DonorViewModel>(entity);
        }
    }
}
