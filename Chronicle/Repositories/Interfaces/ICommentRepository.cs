using Chronicle.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetByBook(int bookId);
    }
}
