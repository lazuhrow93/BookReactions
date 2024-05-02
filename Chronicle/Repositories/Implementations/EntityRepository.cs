using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
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

        public EntityEntry<T> Add(T entity)
        {
            return _context.Add(entity);
        }

        public IEnumerable<EntityEntry<T>> Add(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                yield return _context.Add(entity);
            }
        }

        public EntityEntry<T> Delete(T entity)
        {
            return _context.Remove(entity);
        }

        public IEnumerable<EntityEntry<T>> Delete(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                yield return Delete(entity);
            }
        }

        public T? Get(int id)
        {
            return Query.FirstOrDefault(t => t.Id == id);
        }

        public EntityEntry<T> Update(T entity)
        {
            return _context.Update(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate).AsEnumerable();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
