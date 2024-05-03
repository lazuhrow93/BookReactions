using Chronicle.Domain.Repositories.Interfaces;
using NSubstitute;

namespace Chronicle.Tests.UnitTests.Services
{
    public class ServiceTests<TService>
    {
        protected readonly IAuthorRepository _authorRepo = Substitute.For<IAuthorRepository>();
    }
}
