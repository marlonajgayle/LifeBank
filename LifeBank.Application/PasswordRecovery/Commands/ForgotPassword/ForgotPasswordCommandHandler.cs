using LifeBank.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.PasswordRecovery.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, String>
    {
        private readonly IUserManager userManagerService;

        public ForgotPasswordCommandHandler(IUserManager userManagerService)
        {
            this.userManagerService = userManagerService;
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManagerService.FindUserByEmailAsync(request.Email);

            if (user != null)
            {
                var token = await userManagerService.GeneratePasswordUserTokenAsync(user);
                return token;
                // TODO: send email notification
            }

            return String.Empty;
        }
    }
}
