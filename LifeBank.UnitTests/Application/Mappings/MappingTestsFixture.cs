using AutoMapper;
using LifeBank.Application.Common.Mapping;

namespace LifeBank.UnitTests.Application.Mappings
{
    public class MappingTestsFixture
    {
        public IConfigurationProvider ConfigurationProvider { get; }
        public IMapper Mapper { get; }

        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

    }
}
