using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace LifeBank.Application.Donors.Commands.CreateDonor
{
    public class CreateDonorCommand : IRequest<DonorViewModel>
    {
        public long DonorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodTypeId { get; set; }
        public ICollection<Donation> Donations { get; set; }

        public CreateDonorCommand(DonorViewModel donorViewModel)
        {
            FirstName = donorViewModel.FirstName;
            MiddleInital = donorViewModel.MiddleInital;
            LastName = donorViewModel.LastName;
            Gender = donorViewModel.Gender;
            DateOfBirth = donorViewModel.DateOfBirth;
            BloodTypeId = donorViewModel.BloodTypeId;
        }
    }
}