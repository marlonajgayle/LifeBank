using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Pagination;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentsListQuery : IRequest<List<AppointmentViewModel>>
    {
        public PaginationFilter PaginationFilter { get; set; }

        public GetAppointmentsListQuery(PaginationFilter paginationFilter)
        {
            PaginationFilter = paginationFilter;
        }

    }
}
