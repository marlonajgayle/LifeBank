using MediatR;
using System.Security.Claims;

namespace LifeBank.Application.ChangePassword.Command
{
    public class ChangePasswordCommand : IRequest<Unit>
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPasword { get; set; }
        public ClaimsPrincipal User { get; set; }

        public ChangePasswordCommand(ChangePasswordViewModel viewModel, ClaimsPrincipal user)
        {
            Password = viewModel.Password;
            NewPassword = viewModel.NewPassword;
            User = user;

        }
    }
}
