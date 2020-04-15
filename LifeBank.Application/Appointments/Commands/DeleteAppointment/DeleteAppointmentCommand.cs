using MediatR;

namespace LifeBank.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest
    {
        public long AppointmentId;

        public DeleteAppointmentCommand(long appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}