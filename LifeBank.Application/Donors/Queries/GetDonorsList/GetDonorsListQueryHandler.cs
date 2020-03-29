using AutoMapper;
using LifeBank.Application.Donors.Models;
using LifeBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Queries.GetDonorsList
{
    public class GetDonorsListQueryHandler : IRequestHandler<GetDonorsListQuery, List<DonorViewModel>>
    {
        private readonly LifeBankDbContext dBcontext;
        private readonly IMapper mapper;

        public GetDonorsListQueryHandler(LifeBankDbContext dBcontext, IMapper mapper)
        {
            this.dBcontext = dBcontext;
            this.mapper = mapper;
        }

        public async Task<List<DonorViewModel>> Handle(GetDonorsListQuery request, CancellationToken cancellationToken)
        {
            var donors = await dBcontext.Donors.ToListAsync();

            return mapper.Map<List<DonorViewModel>>(donors);

        }
    }
}
