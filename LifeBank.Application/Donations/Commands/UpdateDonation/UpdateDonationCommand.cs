using MediatR;
using System;

namespace LifeBank.Application.Donations.Commands.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<Unit>
    {
        public long DonationId { get; set; }
        public long DonorId { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }

        public UpdateDonationCommand(Models.DonationViewModel viewModel)
        {
            DonorId = viewModel.DonorId;
            UnitsOfBlood = viewModel.UnitsOfBlood;
            DonationDate = viewModel.DonationDate;
        }
    }
}
