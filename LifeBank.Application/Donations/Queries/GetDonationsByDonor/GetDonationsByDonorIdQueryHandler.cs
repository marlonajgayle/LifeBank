using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Queries.GetDonationsByDonor
{
    public class GetDonationsByDonorIdQueryHandler : IRequestHandler<GetDonationsByDonorIdQuery, List<DonationViewModel>>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public GetDonationsByDonorIdQueryHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<DonationViewModel>> Handle(GetDonationsByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await dbContext.Donations
                .Where(x => x.DonorId == request.DonorId)
                .ProjectTo<DonationViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return entities;
        }
    }
}
