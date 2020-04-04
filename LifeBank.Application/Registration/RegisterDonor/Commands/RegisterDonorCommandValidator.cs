using FluentValidation;
using LifeBank.Application.Registration.Commands;

namespace LifeBank.Application.Registration.RegisterDonor.Commands
{
    public class RegisterDonorCommandValidator : AbstractValidator<RegisterDonorCommand>
    {
        public RegisterDonorCommandValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Please enter the email")
                .EmailAddress().WithMessage("Invalid email address format");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Please enter the password")
                .MinimumLength(6).WithMessage("Password should be greater than 6 characters");

            RuleFor(v => v.ConfirmPassword)
                .NotEmpty().WithMessage("Please enter the confirmation password");

            RuleFor(v => v).Custom((v, context) =>
            {
                if (v.Password != v.ConfirmPassword)
                {
                    context.AddFailure(nameof(v.Password), "Password should match");
                }
            });
        }
    }
}
