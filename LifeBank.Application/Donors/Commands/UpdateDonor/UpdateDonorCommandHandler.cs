using AutoMapper;
using LifeBank.Application.Donors.Models;
using LifeBank.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, DonorViewModel>
    {
        private readonly LifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateDonorCommandHandler(LifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DonorViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            // check to see if donor exist
            var entity = await dbContext.Donors.FindAsync(request.DonorId);

            if (entity != null)
            {
                dbContext.Donors.Remove(entity);
            }
            else
            {
                return null;
            }

            return mapper.Map<DonorViewModel>(entity);
        }
    }
}
