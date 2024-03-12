using Chronicle.Domain.Database.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CommentRepositoryInMemory : ICommentRepository
    {
        private static Dictionary<int, Comment> _comments = new Dictionary<int, Comment>();
        private static Dictionary<int, Comment> _context = new Dictionary<int, Comment>();

        public IQueryable<Comment> comments
        {
            get { return _comments.Values.AsQueryable<Comment>(); }
        }

        public Comment Add(Comment entity)
        {
            _comments.Add(entity.Id, entity);
            return entity;
        }

        public IEnumerable<Comment> Add(IEnumerable<Comment> entities)
        {
            foreach(var entity in entities)
            {
                if(_comments.TryGetValue(entity.Id, out var existingValue) == false)
                {
                    _comments.Add(entity.Id, entity);
                    yield return _comments[entity.Id];
                }
                else
                {
                    yield return Update(entity); //do we wanna do this? maybe throw an exception instead
                }
            }
        }

        public void Delete(Comment entity)
        {
            if(_comments.TryGetValue(entity.Id, out var toDelete))
                _comments.Remove(entity.Id);
        }

        public void Delete(IEnumerable<Comment> entities)
        {
            foreach (var comment in entities)
                Delete(comment);
        }

        public Comment? Get(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context = _comments;
        } 

        public Comment Update(Comment entity)
        {
            _comments[entity.Id] = entity;
            return _comments[entity.Id];
        }
    }
}
