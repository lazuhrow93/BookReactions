using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class EntityRepository<T> : IRepository<T>
        where T : Entity<T>
    {
        private ChronicleDbContext _context;

        public EntityRepository(ChronicleDbContext dbContext)
        {
            _context = dbContext;
        }

        public IQueryable<T> Query
        {
            get { return _context.Set<T>().AsQueryable(); }
        }

        public IEnumerable<T> FetchAll()
        {
            return Query.AsEnumerable();
        }

        public async Task<EntityEntry<T>> Add(T entity)
        {
            return await _context.AddAsync(entity);
        }

        public IEnumerable<EntityEntry<T>> Add(IEnumerable<T> entities)
        {
            var listOfEntries = new List<EntityEntry<T>>();
            foreach(var newEntity in entities)
            {
                listOfEntries.Add(_context.Add(newEntity));
            }
            return listOfEntries;
        }

        public Task<EntityEntry<T>> Delete(T entity)
        {
            return Task.FromResult(_context.Remove(entity));
        }

        public IEnumerable<EntityEntry<T>> Delete(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                yield return Delete(entity);
            }
        }

        public Task<T?> Get(int id)
        {
            return Query.FirstOrDefaultAsync(t => t.Id == id);
        }

        public EntityEntry<T> Update(T entity)
        {
            return _context.Update(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate).AsEnumerable();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<EntityEntry<T>> NoChange(T entity)
        {
            return Task.FromResult(_context.Entry(entity));
        }
    }
}
