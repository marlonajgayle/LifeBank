using AutoMapper;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donations.Queries.GetDonationDetails
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, DonationViewModel>
    {
        private readonly ILifeBankDbContext dbContext;
        private readonly IMapper mapper;

        public GetDonationByIdQueryHandler(ILifeBankDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DonationViewModel> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Donoations.FindAsync(request.DonationId);

            if (entity != null)
            {
                return mapper.Map<DonationViewModel>(entity);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
