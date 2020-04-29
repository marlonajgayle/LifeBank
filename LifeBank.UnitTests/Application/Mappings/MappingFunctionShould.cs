using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Donations.Models;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using Xunit;

namespace LifeBank.UnitTests.Application.Mappings
{
    public class MappingMethodShould : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingMethodShould(MappingTestsFixture fixture)
        {
            configuration = fixture.ConfigurationProvider;
            mapper = fixture.Mapper;
        }

        [Fact]
        public void HaveValidConfiguration()
        {
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void MapDonorToDonorViewModel()
        {
            var entity = new Donor();

            var result = mapper.Map<DonorViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<DonorViewModel>(result);
        }

        [Fact]
        public void MapDonationToDonationViewModel()
        {
            var entity = new Donation();

            var result = mapper.Map<DonationViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<DonationViewModel>(result);
        }

        [Fact]
        public void MapAppointmentToAppointmentViewModel()
        {
            var entity = new Appointment();

            var result = mapper.Map<AppointmentViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<AppointmentViewModel>(result);
        }
    }
}
