using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Authentication.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
    {
        private readonly ISignInManager signInManagerService;

        public LoginCommandHandler(ISignInManager signInManagerService)
        {
            this.signInManagerService = signInManagerService;
        }

        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await signInManagerService.LoginAsync(request.Username, request.Password);

            if (!result.Succeeded)
            {
                throw new BadRequestException("Invalid login");
            }

            return Unit.Value;
        }
    }
}
