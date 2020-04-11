using LifeBank.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.ChangePassword.Command
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly IUserManager userManager;

        public ChangePasswordCommandHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.GetUserAsync(request.User);
            if (user == null)
            {
                throw new Exception();
            }

            var result = await userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }

            return Unit.Value;
        }
    }
}
