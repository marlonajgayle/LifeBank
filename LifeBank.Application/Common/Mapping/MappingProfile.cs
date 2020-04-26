using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Donations.Models;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;

namespace LifeBank.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Donor, DonorViewModel>();
            CreateMap<Donation, DonationViewModel>();
            CreateMap<Appointment, AppointmentViewModel>();
        }
    }
}