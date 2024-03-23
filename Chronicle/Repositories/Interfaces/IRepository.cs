using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        public IQueryable<TEntity> Query { get; }
        public TEntity? Get(int id);
        public EntityEntry<TEntity> Add(TEntity entity);
        public IEnumerable<EntityEntry<TEntity>> Add(IEnumerable<TEntity> entities);
        public EntityEntry<TEntity> Update(TEntity entity);
        public EntityEntry<TEntity> Delete(TEntity entities);
        public IEnumerable<EntityEntry<TEntity>> Delete(IEnumerable<TEntity> entities);
        public int SaveChanges();
    }
}
