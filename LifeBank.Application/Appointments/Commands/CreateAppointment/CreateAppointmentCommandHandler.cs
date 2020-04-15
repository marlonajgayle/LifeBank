using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public CreateAppointmentCommandHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppointmentViewModel> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Appointment()
            {
                DonorId = request.DonorId ,
                LocationId = request.LocationId,
                StartDate = request.StartDate,
                EndDate = request.StartDate.AddMinutes(60)
            };

            dbContext.Appointments.Add(entity);

             await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<AppointmentViewModel>(entity);
        }
    }
}
