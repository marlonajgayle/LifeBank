using System;

namespace LifeBank.Domain.Entities
{
    public class Donation
    {
        public long Id { get; set; }
        public long DonorId { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }
    }
}