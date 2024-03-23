using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Chronicle.Domain.Repositories.Implementations.InMemory
{
    public class AuthorRepositoryInMemory : EntityRepository<Author>
    {
        private object _locker = new object();
        private int _identityId = 1;
        private Dictionary<int, Author> _softCopy = new();
        private Dictionary<int, Author> _hardCopy = new();

        public AuthorRepositoryInMemory(ChronicleDbContext context) : base(context)
        {
            
        }

        public new IQueryable<Author> Query
        {
            get { return _softCopy.Values.AsQueryable<Author>(); }
        }

        public Author Add(Author entity)
        {
            AssignId(entity);
            _softCopy.Add(entity.Id, entity);
            return entity;
        }

        public IEnumerable<Author> Add(IEnumerable<Author> authors)
        {
            var startId = _identityId;
            foreach (var author in authors)
            {
                AssignId(author);
                _softCopy[author.Id] = author;
            }
            var finalId = _identityId;
            return _softCopy.Where(d => d.Key >= startId && d.Key < finalId).Select(d => d.Value);
        }

        public void Delete(Author author)
        {
            _softCopy.Remove(author.Id);
        }

        public void Delete(IEnumerable<Author> entities)
        {
            foreach(var author in entities)
            {
                _softCopy.Remove(author.Id);
            }
        }

        public Author? Get(int id)
        {
            _softCopy.TryGetValue(id, out var author);
            return author;
        }

        public void SaveChanges()
        {
            _hardCopy = _softCopy;
        }

        public Author Update(Author author)
        {
            _softCopy[author.Id] = author;
            return _softCopy[author.Id];
        }
        private void AssignId(Author author)
        {
            lock (_locker)
            {
                author.Id = _identityId++;
            }
        }
    }
}
