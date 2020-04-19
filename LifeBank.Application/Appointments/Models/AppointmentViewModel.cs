using LifeBank.Domain.Enums;
using System;

namespace LifeBank.Application.Appointments.Models
{
    public class AppointmentViewModel
    {
        public long AppointmentId { get; set; }
        public long DonorId { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
