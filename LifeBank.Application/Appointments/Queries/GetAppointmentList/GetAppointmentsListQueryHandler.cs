using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentViewModel>>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public GetAppointmentsListQueryHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<AppointmentViewModel>> Handle(GetAppointmentsListQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.PaginationFilter.Page - 1) * (request.PaginationFilter.Size);
            var entities = await dbContext.Appointments
                .ProjectTo<AppointmentViewModel>(mapper.ConfigurationProvider)
                .Skip(skip)
                .Take(request.PaginationFilter.Size)
                .ToListAsync();

            return entities;
        }
    }
}
