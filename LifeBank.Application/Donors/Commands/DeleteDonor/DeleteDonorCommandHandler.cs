using LifeBank.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.DeleteDonor
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand>
    {
        private readonly LifeBankDbContext dbContext;

        public DeleteDonorCommandHandler(LifeBankDbContext dbContext)
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
                throw new Exception();
            }


            return Unit.Value;
        }
    }
}
