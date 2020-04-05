using FluentValidation;

namespace LifeBank.Application.PasswordRecovery.Commands.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty()
                .EmailAddress();
        } 
    }
}
