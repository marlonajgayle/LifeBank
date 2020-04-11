using LifeBank.Application.Donations.Models;
using MediatR;

namespace LifeBank.Application.Donations.Queries.GetDonationDetails
{
    public class GetDonationByIdQuery : IRequest<DonationViewModel>
    {
        public long DonationId { get; set; }

        public GetDonationByIdQuery(long donationId)
        {
            DonationId = donationId;
        }
    }
}
