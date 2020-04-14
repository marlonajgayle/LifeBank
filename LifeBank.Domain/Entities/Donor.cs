using LifeBank.Domain.Common;
using System;
using System.Collections.Generic;

namespace LifeBank.Domain.Entities
{
    public class Donor : AuditableEntity
    {
        public long DonorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }
        public ICollection<Donation> Donations { get; private set; }
        public ICollection<Appointment> Appointments { get; set; }

        public Donor()
        {
            Donations = new List<Donation>();
        }
    }
}
