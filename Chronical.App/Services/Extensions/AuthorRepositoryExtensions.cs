using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using SpicyWing.Extensions;

namespace Chronical.App.Services.Extensions
{
    public static class AuthorRepositoryExtensions
    {
        public static Author? GetByFullName(this IAuthorRepository repo, string firstname, string? middlename, string lastname)
        {
            Func<Author, bool> satisfiesNameFilters;
            if(string.IsNullOrEmpty(middlename))
                satisfiesNameFilters = a => a.LastName!.Like(lastname) && a.FirstName!.Like(firstname);
            else
                satisfiesNameFilters = a => a.LastName!.Like(lastname) && a.MiddleName!.Like(middlename) && a.FirstName!.Like(firstname);

            var result = repo.Query.Where(satisfiesNameFilters);

            return result.FirstOrDefault();
        }
    }
}
