using AutoMapper;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, DonationViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public CreateDonationCommandHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DonationViewModel> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Donation()
            {
                DonorId = request.DonorId,
                UnitsOfBlood = request.UnitsOfBlood,
                DonationDate = request.DonationDate
            };

            dbContext.Donations.Add(entity);

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<DonationViewModel>(entity);
        }
    }
}
