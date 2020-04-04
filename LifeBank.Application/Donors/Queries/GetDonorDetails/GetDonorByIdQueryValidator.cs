using FluentValidation;

namespace LifeBank.Application.Donors.Queries.GetDonorDetails
{
    public class GetDonorByIdQueryValidator : AbstractValidator<GetDonorByIdQuery>
    {
        public GetDonorByIdQueryValidator()
        {
            RuleFor(v => v.DonorId).NotEmpty().WithMessage("Donor Id must not be empty!");
        }
    }
}
