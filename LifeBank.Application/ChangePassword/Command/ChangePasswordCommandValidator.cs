using FluentValidation;

namespace LifeBank.Application.ChangePassword.Command
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(v => v.Password)
                .NotEmpty();

            RuleFor(v => v.NewPassword)
                .NotEmpty();

            RuleFor(v => v.ConfirmPasword)
                .NotEmpty()
                .Equal(v => v.Password);

        }

    }
}
