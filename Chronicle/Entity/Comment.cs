using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Comment : Entity<Comment>
    {
        public int BookId { get; set; }
        public string? SubText { get; set; }
        public int ChapterId { get; set; }
        public string? Value { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
