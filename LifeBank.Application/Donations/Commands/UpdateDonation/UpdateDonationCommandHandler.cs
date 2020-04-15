using AutoMapper;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Unit = MediatR.Unit;

namespace LifeBank.Application.Donations.Commands.UpdateDonation
{
    public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, DonationViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDonationCommandHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DonationViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donations.FindAsync(request.DonationId);

            if (entity != null)
            {
                entity.DonorId = request.DonorId;
                entity.UnitsOfBlood = request.UnitsOfBlood;
                entity.DonationDate = request.DonationDate;

                await dbContext.SaveChangesAsync(cancellationToken);

                return mapper.Map<DonationViewModel>(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Donation), request.DonationId);
            }
        }
    }
}
