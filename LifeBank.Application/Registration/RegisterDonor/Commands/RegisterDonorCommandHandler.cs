using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Registration.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Registration.RegisterDonor.Commands
{
    public class RegisterDonorCommandHandler : IRequestHandler<RegisterDonorCommand, Unit>
    {
        public ILifeBankDbContext DbContext { get; }

        public RegisterDonorCommandHandler(ILifeBankDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<Unit> Handle(RegisterDonorCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
