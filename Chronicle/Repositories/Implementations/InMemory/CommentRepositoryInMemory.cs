using Chronicle.Domain.Database.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations.InMemory
{
    public class CommentRepositoryInMemory : EntityRepository<Comment>
    {
        private static Dictionary<int, Comment> _softCopy = new Dictionary<int, Comment>();
        private static Dictionary<int, Comment> _hardCopy = new Dictionary<int, Comment>();

        public CommentRepositoryInMemory(ChronicleDbContext context) : base(context)
        {
            
        }

        public IQueryable<Comment> Query
        {
            get { return _softCopy.Values.AsQueryable(); }
        }

        public Comment Add(Comment entity)
        {
            _softCopy.Add(entity.Id, entity);
            return entity;
        }

        public IEnumerable<Comment> Add(IEnumerable<Comment> entities)
        {
            foreach (var entity in entities)
            {
                if (_softCopy.TryGetValue(entity.Id, out var existingValue) == false)
                {
                    _softCopy.Add(entity.Id, entity);
                    yield return _softCopy[entity.Id];
                }
                else
                {
                    yield return Update(entity); //do we wanna do this? maybe throw an exception instead
                }
            }
        }

        public void Delete(Comment entity)
        {
            if (_softCopy.TryGetValue(entity.Id, out var toDelete))
                _softCopy.Remove(entity.Id);
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
            _hardCopy = _softCopy;
        }

        public Comment Update(Comment entity)
        {
            _softCopy[entity.Id] = entity;
            return _softCopy[entity.Id];
        }
    }
}
