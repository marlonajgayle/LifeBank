using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.DeleteDonor
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand>
    {
        private readonly ILifeBankDbContext dbContext;

        public DeleteDonorCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donors.FindAsync(request.DonorId);

            if (entity != null)
            {
                dbContext.Donors.Remove(entity);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Donor), request.DonorId);
            }

            return Unit.Value;
        }
    }
}
