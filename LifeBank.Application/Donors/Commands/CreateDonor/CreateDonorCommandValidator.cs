using FluentValidation;

namespace LifeBank.Application.Donors.Commands.CreateDonor
{
    public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorCommandValidator()
        {
            RuleFor(v => v.FirstName).MaximumLength(30).NotEmpty();
            RuleFor(v => v.LastName).MaximumLength(30).NotEmpty();
            RuleFor(v => v.Gender).NotEmpty();
            RuleFor(v => v.DateOfBirth).NotEmpty();
            RuleFor(v => v.BloodType).Length(3).NotEmpty();
        }
    }
}