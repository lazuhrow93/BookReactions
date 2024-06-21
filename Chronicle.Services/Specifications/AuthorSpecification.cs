using Chronicle.Domain.Entity;
using System.Net.Http.Headers;

namespace Chronicle.Services.Specifications
{
    public class AuthorSpecification : BaseSpecification<Author>
    {
        public AuthorSpecification()
        {
            
        }

        public static AuthorSpecification ByAuthorNames(string? firstname, string? middlename, string? lastName)
        {
            return new AuthorSpecification()
            {
                Criteria = a
                    => (firstname == null || a.FirstName == firstname)
                    && (middlename == null || a.MiddleName == middlename)
                    && (lastName == null || a.LastName == lastName)
            };
        }
    }
}
