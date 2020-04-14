using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.PasswordRecovery.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IUserManager userManagerService;

        public ResetPasswordCommandHandler(IUserManager userManagerService)
        {
            this.userManagerService = userManagerService;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManagerService.FindUserByEmailAsync(request.Email);

            if (user != null)
            {
                var result = await userManagerService.ResetPasswordAsync(user, request.Token, request.Password);

                return result;
            }
            else
            {
                throw new NotFoundException("User", request.Email);
            }
        }
    }
}
