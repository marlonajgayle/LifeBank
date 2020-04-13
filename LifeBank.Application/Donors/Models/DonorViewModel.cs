using LifeBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LifeBank.Application.Donors.Models
{
    public class DonorViewModel
    {
        public long DonorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodTypeId { get; set; }
        public ICollection<Donation> Donations { get; set; }
    }
}
