using AutoMapper;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using LifeBank.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Queries
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, DonorViewModel>
    {
        private readonly IMapper mapper;
        private readonly LifeBankDbContext dBContext;

        public GetDonorByIdQueryHandler(IMapper mapper, LifeBankDbContext dBContext)
        {
            this.mapper = mapper;
            this.dBContext = dBContext;
        }

        public async Task<DonorViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            Donor entity = await dBContext.Donors.FindAsync(request.DonorId);
            return mapper.Map<DonorViewModel>(entity);
        }
    }
}
