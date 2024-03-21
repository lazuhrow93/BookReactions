using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using SpicyWing.Extensions;
using System.Runtime.CompilerServices;

namespace Chronical.App.Services.Extensions
{
    public static class AuthorRepositoryExtensions
    {
        public static Author? GetByFullName(this IAuthorRepository repo, string firstname, string middlename, string lastname)
        {
            return repo.Query
                .Where(a => a.LastName.Like(lastname) && a.MiddleName.Like(middlename) && a.FirstName.Like(firstname))
                .FirstOrDefault();
        }
    }
}
