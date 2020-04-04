using AutoMapper;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Queries.GetDonorsList
{
    public class GetDonorsListQueryHandler : IRequestHandler<GetDonorsListQuery, List<DonorViewModel>>
    {
        private readonly ILifeBankDbContext dBcontext;
        private readonly IMapper mapper;

        public GetDonorsListQueryHandler(ILifeBankDbContext dBcontext, IMapper mapper)
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
