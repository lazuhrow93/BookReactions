using Bogus;
using Chronicle.Domain.Entity;
using Chronicle.Tests.Utility.Faker;

namespace Chronical.App.Helper
{
    public class AuthorFaker : EntityFaker<Author>
    {
        public AuthorFaker()
        {
            RuleFor(t => t.FirstName, f => f.Person.FirstName);
            RuleFor(t => t.LastName, f => f.Person.LastName);
            RuleFor(t => t.MiddleName, _ => null);
        }
    }
}
