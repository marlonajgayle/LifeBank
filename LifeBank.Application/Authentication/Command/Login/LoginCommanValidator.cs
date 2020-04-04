using FluentValidation;

namespace LifeBank.Application.Authentication.Command.Login
{
    public class LoginCommanValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommanValidator()
        {
            RuleFor(v => v.Username)
                .NotEmpty()
                .EmailAddress();

            RuleFor(v => v.Password)
                .NotEmpty();
        }
    }
}
