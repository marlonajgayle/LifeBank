using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Queries.GetAppointmentDetails
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public GetAppointmentByIdQueryHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppointmentViewModel> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Appointments.FindAsync(request.AppointmentId);

            if (entity != null)
            {
                return mapper.Map<AppointmentViewModel>(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }
        }
    }
}
