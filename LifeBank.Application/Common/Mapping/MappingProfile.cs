using AutoMapper;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;

namespace LifeBank.Application.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Donor, DonorViewModel>();
        }
    }
}