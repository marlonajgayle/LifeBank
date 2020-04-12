using LifeBank.Application.Appointments.Models;
using MediatR;

namespace LifeBank.Application.Appointments.Queries.GetAppointmentDetails
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentViewModel>
    {
        public long AppointmentId { get; set; }

        public GetAppointmentByIdQuery(long appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
