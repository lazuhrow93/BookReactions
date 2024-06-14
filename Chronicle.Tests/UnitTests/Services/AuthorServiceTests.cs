using AutoMapper;
using Chronicle.Tests.UnitTests.MapperProfiles;
using Xunit;
using Chronical.App.Mappers;
using Chronical.App.Helper;
using Chronical.App.Services.Extensions;
using Chronical.App.Models.IncomingDto;
using NSubstitute;
using Chronicle.Tests.Utility.Extensions;
using Chronical.App.Services.Implementations.Old;
using Chronical.App.Services.Interfaces.Old;

namespace Chronicle.Tests.UnitTests.Services
{
    public class AuthorServiceTests : ServiceTests<AuthorService>
    {
        private readonly IMapper _mapper = MapperTests<DtoProfile>.CreateMapper();
        private readonly IAuthorService _service;

        public AuthorServiceTests()
        {
            _service = new AuthorService(_authorRepo, _mapper);    
        }

        [Fact]
        public void Add_Should_ReturnErrorOnExists()
        {
            var authorEntity = new AuthorFaker().Generate();
            
            _authorRepo
                .GetByFullName(authorEntity.FirstName!, authorEntity.MiddleName, authorEntity.LastName!)
                .Returns(authorEntity);

            var result = _service.AddAuthor(new AuthorDto()
            {
                FirstName = authorEntity.FirstName,
                MiddleName = authorEntity.MiddleName,
                LastName = authorEntity.LastName,
            });

            result
                .AssertEntityFound();
        } 
    }
}
