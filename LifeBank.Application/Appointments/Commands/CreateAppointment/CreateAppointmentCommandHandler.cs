using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly ILifeBankDbContext dbContext;

        public CreateAppointmentCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Appointment()
            {
                Donor = new Donor() { DonorId = request.DonorId },
                Location = new Location() { LocationId = request.LocationId },
                StartDate = request.StartDate,
                EndDate = request.StartDate.AddMinutes(60)
            };

            dbContext.Appointments.Add(entity);

            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
