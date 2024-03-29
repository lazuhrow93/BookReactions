using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Character : Entity<Character>
    {
        public string? FullName { get; set; }
        public int BookId { get; set; }
    }
}
