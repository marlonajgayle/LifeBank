using LifeBank.Application.Appointments.Models;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentsListQuery : IRequest<List<AppointmentViewModel>>
    {
    }
}
