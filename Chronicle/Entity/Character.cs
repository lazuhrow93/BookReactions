using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Character : Entity
    {
        public string? FullName { get; set; }
        public int BookId { get; set; }
    }
}
