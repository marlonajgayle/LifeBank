using LifeBank.Application.Appointments.Models;
using LifeBank.Domain.Entities;
using LifeBank.Domain.Enums;
using MediatR;
using System;

namespace LifeBank.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public long AppointmentId { get; set; }
        public long DonorId { get; set; }
        public long LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public CreateAppointmentCommand(AppointmentViewModel viewModel)
        {
            DonorId = viewModel.Donor.DonorId;
            LocationId = viewModel.Location.LocationId;
            StartDate = viewModel.StartDate;
            Status = AppointmentStatus.None;
        }

    }
}
