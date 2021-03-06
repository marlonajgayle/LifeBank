﻿using AutoMapper;
using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Queries
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, DonorViewModel>
    {
        private readonly IMapper mapper;
        private readonly ILifeBankDbContext dBContext;

        public GetDonorByIdQueryHandler(IMapper mapper, ILifeBankDbContext dBContext)
        {
            this.mapper = mapper;
            this.dBContext = dBContext;
        }

        public async Task<DonorViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            Donor entity = await dBContext.Donors
                .SingleOrDefaultAsync(x => x.DonorId == request.DonorId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Donor), request.DonorId);
            }

            return mapper.Map<DonorViewModel>(entity);
        }
    }
}
