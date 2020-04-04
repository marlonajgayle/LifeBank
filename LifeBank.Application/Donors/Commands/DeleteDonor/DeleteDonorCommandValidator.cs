using FluentValidation;

namespace LifeBank.Application.Donors.Commands.DeleteDonor
{
    public class DeleteDonorCommandValidator : AbstractValidator<DeleteDonorCommand>
    {
        public DeleteDonorCommandValidator()
        {
            RuleFor(v => v.DonorId).NotEmpty();
        }
    }
}
