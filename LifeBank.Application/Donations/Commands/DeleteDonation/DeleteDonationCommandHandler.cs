using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Commands.DeleteDonation
{
    public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, Unit>
    {
        private readonly ILifeBankDbContext dbContext;

        public DeleteDonationCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donations.FindAsync(request.DonationId);

            if (entity != null)
            {
                dbContext.Donations.Remove(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Donation), request.DonationId);
            }

            return Unit.Value;
        }
    }
}
