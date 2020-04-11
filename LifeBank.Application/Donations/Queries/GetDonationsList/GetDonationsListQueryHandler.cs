using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Queries.GetDonationsList
{
    public class GetDonationsListQueryHandler : IRequestHandler<GetDonationsListQuery, List<DonationViewModel>>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public GetDonationsListQueryHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<DonationViewModel>> Handle(GetDonationsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await dbContext.Donoations
                .ProjectTo<DonationViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return entities;
        }
    }
}
