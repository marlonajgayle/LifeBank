using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly ILifeBankDbContext dbContext;

        public DeleteAppointmentCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Appointments.FindAsync(request.AppointmentId);

            if (entity != null)
            {
                dbContext.Appointments.Remove(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }

            return Unit.Value;
        }
    }
}
