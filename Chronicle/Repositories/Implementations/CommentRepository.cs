using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CommentRepository : EntityRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ChronicleDbContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetByBook(int bookId)
        {
            return Query.Where(c => c.BookId == bookId).AsEnumerable();
        }
    }
}
