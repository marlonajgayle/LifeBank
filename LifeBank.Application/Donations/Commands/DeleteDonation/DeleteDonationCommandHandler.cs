using LifeBank.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Commands.DeleteDonation
{
    public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, int>
    {
        private readonly ILifeBankDbContext dbContext;

        public DeleteDonationCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donoations.FindAsync(request.DonationId);

            if (entity != null)
            {
                dbContext.Donoations.Remove(entity);
                return await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new System.Exception();
            }
        }
    }
}
