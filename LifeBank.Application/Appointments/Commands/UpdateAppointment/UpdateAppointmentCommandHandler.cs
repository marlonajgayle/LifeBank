using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, AppointmentViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateAppointmentCommandHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppointmentViewModel> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Appointments.FindAsync(request.AppointmentId);

            if (entity != null)
            {
                entity.DonorId = request.DonorId;
                entity.StartDate = request.StartDate;
                entity.EndDate = request.StartDate.AddHours(60);
                entity.LocationId = request.LocationId;

                await dbContext.SaveChangesAsync(cancellationToken);

                return mapper.Map<AppointmentViewModel>(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }

        }
    }
}
