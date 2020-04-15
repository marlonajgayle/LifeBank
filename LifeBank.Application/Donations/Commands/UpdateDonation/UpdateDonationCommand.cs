using LifeBank.Application.Donations.Models;
using MediatR;
using System;

namespace LifeBank.Application.Donations.Commands.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<DonationViewModel>
    {
        public long DonationId { get; set; }
        public long DonorId { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }

        public UpdateDonationCommand(long donationId, DonationViewModel viewModel)
        {
            DonationId = donationId;
            DonorId = viewModel.DonorId;
            UnitsOfBlood = viewModel.UnitsOfBlood;
            DonationDate = viewModel.DonationDate;
        }
    }
}
