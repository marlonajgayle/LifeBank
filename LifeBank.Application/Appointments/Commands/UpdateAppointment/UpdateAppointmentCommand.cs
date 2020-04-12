using LifeBank.Application.Appointments.Models;
using LifeBank.Domain.Entities;
using LifeBank.Domain.Enums;
using MediatR;
using System;

namespace LifeBank.Application.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<int>
    {
        public long AppointmentId { get; set; }
        public Donor Donor { get; set; }
        public Location Location { get; set; }
        public DateTime StartDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public UpdateAppointmentCommand(AppointmentViewModel viewModel)
        {
            Donor = viewModel.Donor;
            Location = viewModel.Location;
            StartDate = viewModel.StartDate;
            Status = viewModel.Status;
        }
    }
}
