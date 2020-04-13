using LifeBank.Domain.Common;
using System;

namespace LifeBank.Domain.Entities
{
    public class Donation : AuditableEntity
    {
        public long DonationId { get; set; }
        public long DonorId { get; set; }
        public Donor Donor { get; set; }
        public int UnitsOfBlood { get; set; }
        public DateTime DonationDate { get; set; }
    }
}