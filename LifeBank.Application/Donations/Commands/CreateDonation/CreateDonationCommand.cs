using LifeBank.Application.Donations.Models;
using MediatR;
using System;

namespace LifeBank.Application.Donations.Commands.CreateDonation
{
    public class CreateDonationCommand : IRequest<DonationViewModel>
    {
        public long DonationId { get; set; }
        public long DonorId { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }

        public CreateDonationCommand(DonationViewModel viewModel)
        {
            DonorId = viewModel.DonorId;
            UnitsOfBlood = viewModel.UnitsOfBlood;
            DonationDate = viewModel.DonationDate;
        }
    }
}
