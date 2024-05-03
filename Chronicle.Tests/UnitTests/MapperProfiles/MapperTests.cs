using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chronicle.Tests.UnitTests.MapperProfiles
{
    public class MapperTests<TMapperProfile>
        where TMapperProfile : Profile, new()
    {
        protected MapperConfiguration _config;
        protected IMapper mapper;

        public MapperTests()
        {
            _config = new MapperConfiguration(cfg => cfg.AddProfile<TMapperProfile>());
            mapper = new Mapper(_config);
        }

        [Fact]
        public void HasCorrectConfig()
        {
            _config.AssertConfigurationIsValid();
        }

        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TMapperProfile>());
            return new Mapper(config);
        }
    }
}
