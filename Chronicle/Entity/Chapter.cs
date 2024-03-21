using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Chapter : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int Number { get; set; }
    }
}
