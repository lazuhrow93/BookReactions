using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private ChronicleDBContext _context { get; set; }
        private IQueryable<Comment> _comments
        {
            get { return _context.Set<Comment>().AsQueryable(); }
        }

        public CommentRepository(ChronicleDBContext context)
        {
            _context = context;
            _comments = FetchAll();
        }

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> FetchAll()
        {
            return _comments;
        }

        public Comment Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment Add(IEnumerable<Comment> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Comment> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Delete(Comment entity)
        {
            _context.Remove<Comment>(entity);
        }

        public Comment Update(Comment entity)
        {
            return _context.Update(entity).Entity;
        }

        public Comment? Get(int id)
        {
            return _comments.FirstOrDefault(c => c.Id == id);
        }

        IEnumerable<Comment> IRepository<Comment>.Add(IEnumerable<Comment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
