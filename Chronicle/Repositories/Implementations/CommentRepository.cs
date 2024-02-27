using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private ChronicleDBContext _context;

        public CommentRepository(ChronicleDBContext context)
        {
            _context = context;    
        }

        public IEnumerable<Comment> UnderChapter(int chapterId)
        {
            var all = FetchAll().Where(c => c.ChapterId == chapterId);
            return all ?? Enumerable.Empty<Comment>();
        }

        public IQueryable<Comment> FetchAll()
        {
            return _context.Comment.AsQueryable<Comment>();
        }
    }
}
