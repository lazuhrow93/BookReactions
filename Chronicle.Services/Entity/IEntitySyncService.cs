using Chronicle.Services.Specifications;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chronicle.Services.Entity
{
    public interface IEntitySyncService
    {
        Task<IEnumerable<T>> Get<T>(ISpecification<T> specification)
            where T : Domain.Entity.Entity;
        Task<EntityEntry<T>> Merge<T>(T Entity, SyncOptions options)
            where T : Domain.Entity.Entity;
        Task<EntityEntry<T>> Delete<T>(T Entity)
            where T : Domain.Entity.Entity, new();
        Task<EntityEntry<T>> Add<T>(T entity)
            where T : Domain.Entity.Entity;
    }
}