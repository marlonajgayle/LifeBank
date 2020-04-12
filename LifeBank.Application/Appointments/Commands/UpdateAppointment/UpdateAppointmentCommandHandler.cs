using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, int>
    {
        private readonly ILifeBankDbContext dbContext;

        public UpdateAppointmentCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity =  await dbContext.Appointments.FindAsync(request.AppointmentId);

            if (entity != null)
            {
                entity.Donor = request.Donor;
                entity.StartDate = request.StartDate;
                entity.EndDate = request.StartDate.AddHours(60);
                entity.Location = request.Location;

                return await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                //throw new NotFoundException(nameof(Appointment), request.AppointmentId);
                throw new Exception();
            }

        }
    }
}
