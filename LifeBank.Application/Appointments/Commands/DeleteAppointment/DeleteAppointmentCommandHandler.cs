using LifeBank.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, int>
    {
        private readonly ILifeBankDbContext dbContext;

        public DeleteAppointmentCommandHandler(ILifeBankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Appointments.FindAsync(request.AppointmentId);

            if (entity != null)
            {
                dbContext.Appointments.Remove(entity);
                return await dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
