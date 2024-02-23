using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CommentRepository : IRepository<Comment>
    {
        public Comment Get(int id)
        {
            throw new NotImplementedException("IMPLEMENT DB TO GET COMMENTS BY ID");
        }

        public IQueryable<Comment> FetchAll()
        {
            throw new NotImplementedException("IMPLEMENT DB TO GET ALL");
        }
    }
}
