using FluentValidation;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandValidator : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorCommandValidator()
        {
            RuleFor(v => v.DonorId).NotEmpty();
            RuleFor(v => v.FirstName).MaximumLength(30).NotEmpty();
            RuleFor(v => v.LastName).MaximumLength(30).NotEmpty();
            RuleFor(v => v.Gender).NotEmpty();
            RuleFor(v => v.DateOfBirth).NotEmpty();
        }
    }
}
