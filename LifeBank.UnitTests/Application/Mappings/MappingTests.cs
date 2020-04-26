using AutoMapper;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Donations.Models;
using LifeBank.Application.Donors.Models;
using LifeBank.Domain.Entities;
using Xunit;

namespace LifeBank.UnitTests.Application.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            configuration = fixture.ConfigurationProvider;
            mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapDonorToDonorViewModel()
        {
            var entity = new Donor();

            var result = mapper.Map<DonorViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<DonorViewModel>(result);
        }

        [Fact]
        public void ShouldMapDonationToDonationViewModel()
        {
            var entity = new Donation();

            var result = mapper.Map<DonationViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<DonationViewModel>(result);
        }

        [Fact]
        public void ShouldMapAppointmentToAppointmentViewModel()
        {
            var entity = new Appointment();

            var result = mapper.Map<AppointmentViewModel>(entity);

            Assert.NotNull(result);
            Assert.IsType<AppointmentViewModel>(result);
        }
    }
}
