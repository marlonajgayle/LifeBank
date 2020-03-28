﻿using AutoMapper;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using LifeBank.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Donors.Commands.CreateDonor
{
    public class CreateDonorCommandHandler : MediatR.IRequestHandler<CreateDonorCommand, DonorViewModel>
    {
        private readonly LifeBankDbContext DbContext;
        private readonly IMapper Mapper;


        public CreateDonorCommandHandler(LifeBankDbContext dBContext, IMapper mapper)
        {
            DbContext = dBContext;
            Mapper = mapper;
        }

        public async Task<DonorViewModel> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            Donor entity = new Donor
            {
                DonorId = request.DonorId,
                FirstName = request.FirstName,
                MiddleInital = request.MiddleInital,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                BloodType = request.BloodType
            };

            DbContext.Donors.Add(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            DonorViewModel response = Mapper.Map<DonorViewModel>(entity);

            return response;
        }
    }
}