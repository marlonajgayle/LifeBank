using LifeBank.Domain.Common;
using System;

namespace LifeBank.Domain.Entities
{
    public class Appointment : AuditableEntity
    {
        public long AppointmentId { get; set; }
        public long DonorId { get; set; }
        public Donor Donor { get; set; }
        public Location Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
