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
            var skip = (request.PaginationFilter.Page - 1) * (request.PaginationFilter.Size);

            var entities = await dbContext.Donations
                .ProjectTo<DonationViewModel>(mapper.ConfigurationProvider)
                .Skip(skip)
                .Take(request.PaginationFilter.Size)
                .ToListAsync(cancellationToken);

            return entities;
        }
    }
}
