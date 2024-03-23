using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Book : Entity<Book>
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }

    }
}
