using Chronicle.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Services.Specifications
{
    public class BookSpecification : BaseSpecification<Book>
    {
        public static BookSpecification ByAuthorIdAndTitle(int authorId, string? title)
        {
            return new BookSpecification()
            {
                Criteria = b
                    => b.AuthorId == authorId && (title == null || b.Title == title)
            };
        }
    }
}
