using LifeBank.Application.Appointments.Models;
using LifeBank.Domain.Enums;
using MediatR;
using System;

namespace LifeBank.Application.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<AppointmentViewModel>
    {
        public long AppointmentId { get; set; }
        public long DonorId { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public UpdateAppointmentCommand(long appointmentId, AppointmentViewModel viewModel)
        {
            DonorId = viewModel.DonorId;
            LocationId = viewModel.LocationId;
            StartDate = viewModel.StartDate;
            Status = viewModel.Status;
        }
    }
}
