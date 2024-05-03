
using Chronicle.Domain.Repositories.Interfaces;
using NSubstitute;
using Xunit;

namespace Chronicle.Tests.UnitTests.Services
{
    public class AuthorServiceTests
    {
        public AuthorServiceTests()
        {
            
        }

        [Fact]
        public void Add_Should_ReturnErrorOnExists()
        {

        } 
    }

    public class ServiceTests<TService>
    {
        protected readonly IAuthorRepository _authorRepo = Substitute.For<IAuthorRepository>();
        protected readonly 

    }
}
