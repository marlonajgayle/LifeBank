using LifeBank.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Unit = MediatR.Unit;

namespace LifeBank.Application.Donations.Commands.UpdateDonation
{
    public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, Unit>
    {
        private readonly ILifeBankDbContext dbContext;

        public UpdateDonationCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donations.FindAsync(request.DonationId);

            if (entity != null)
            {
                entity.DonorId = request.DonorId;
                entity.UnitsOfBlood = request.UnitsOfBlood;
                entity.DonationDate = request.DonationDate;

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new System.Exception();
            }

            return Unit.Value;
        }
    }
}
