using System;

namespace LifeBank.Application.Donations.Models
{
    public class DonationViewModel
    {
        public long DonationId { get; set; }
        public long DonorId { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
