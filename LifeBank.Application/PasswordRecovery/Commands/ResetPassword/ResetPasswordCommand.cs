using LifeBank.Application.Common.Models;
using MediatR;

namespace LifeBank.Application.PasswordRecovery.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

        public ResetPasswordCommand(ResetPasswordViewModel viewModel)
        {
            Email = viewModel.Email;
            Password = viewModel.Password;
            Token = viewModel.Token;
        }
    }
}
