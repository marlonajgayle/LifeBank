using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
    {
        private readonly ILifeBankDbContext dbContext;

        public CreateDonationCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Donation()
            {
                DonorId = request.DonorId,
                UnitsOfBlood = request.UnitsOfBlood,
                DonationDate = request.DonationDate
            };

            dbContext.Donations.Add(entity);

            var response = await dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
