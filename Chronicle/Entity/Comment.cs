using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? SubText { get; set; }
        public int ChapterId { get; set; }
        public string? CommentLiteral { get; set; }
        public bool Spoiler { get; set; }
    }
}
