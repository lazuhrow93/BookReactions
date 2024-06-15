using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Chronicle.Domain.Entity;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity.Entity
    {
        public IQueryable<TEntity> Query { get; }
        public IEnumerable<TEntity> FetchAll();
        public Task<TEntity?> Get(int id);
        Task<EntityEntry<TEntity>> Add(TEntity entity);
        public IEnumerable<EntityEntry<TEntity>> Add(IEnumerable<TEntity> entities);
        public EntityEntry<TEntity> Update(TEntity entity);
        public Task<EntityEntry<TEntity>> Delete(TEntity entities);
        public IEnumerable<EntityEntry<TEntity>> Delete(IEnumerable<TEntity> entities);
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        public Task<int> SaveChanges();
        Task<EntityEntry<TEntity>> NoChange(TEntity entity);
    }
}
