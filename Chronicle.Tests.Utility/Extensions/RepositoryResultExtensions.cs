using Chronicle.Domain.Repositories;
using FluentAssertions;

namespace Chronicle.Tests.Utility.Extensions
{
    public static class RepositoryResultExtensions
    {
        public static RepositoryResult<TEntity> AssertEntityFound<TEntity>(this RepositoryResult<TEntity> result)
        {
            result.EntityFound.Should().BeTrue();
            return result;
        }
    }
}
