using MediatR;

namespace LifeBank.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<int>
    {
        public long AppointmentId;

        public DeleteAppointmentCommand(long appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}