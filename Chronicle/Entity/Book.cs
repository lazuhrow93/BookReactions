using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
