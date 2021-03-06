﻿using AutoMapper;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Models;
using LifeBank.Domain.Entities;
using MediatR;
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
            var entity = await dbContext.Donations.FindAsync(request.DonationId);

            if (entity != null)
            {
                return mapper.Map<DonationViewModel>(entity);
            }
            else
            {
                throw new NotFoundException(nameof(Donation), request.DonationId);
            }
        }
    }
}
