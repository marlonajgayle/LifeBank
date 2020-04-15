using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<DonorViewModel>
    {
        public long DonorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodTypeId { get; set; }
        public ICollection<Donation> Donations { get; set; }

        public UpdateDonorCommand(long donorId, DonorViewModel viewModel)
        {
            DonorId = donorId;
            FirstName = viewModel.FirstName;
            MiddleInital = viewModel.MiddleInital;
            LastName = viewModel.LastName;
            Gender = viewModel.Gender;
            DateOfBirth = viewModel.DateOfBirth;
            BloodTypeId = viewModel.BloodTypeId;
        }
    }
}
