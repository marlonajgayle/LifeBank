using MediatR;
using System;

namespace LifeBank.Application.PasswordRecovery.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<String>
    {
        public string Email { get; set; }

        public ForgotPasswordCommand(ForgotPasswordViewModel viewModel)
        {
            Email = viewModel.Email;
        }
    }
}
