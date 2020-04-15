using MediatR;

namespace LifeBank.Application.Donations.Commands.DeleteDonation
{
    public class DeleteDonationCommand : IRequest
    {
        public long DonationId { get; set; }

        public DeleteDonationCommand(long donationId)
        {
            DonationId = donationId;
        }
    }
}
