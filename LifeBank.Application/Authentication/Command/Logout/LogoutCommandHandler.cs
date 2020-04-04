using LifeBank.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Authentication.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly ISignInManager signInManager;

        public LogoutCommandHandler(ISignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            signInManager.LogoutAsync();

            return Unit.Value;
        }
    }
}
