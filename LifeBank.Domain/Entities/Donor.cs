using System;

namespace LifeBank.Domain.Entities
{
    public class Donor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInital { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
    }
}
