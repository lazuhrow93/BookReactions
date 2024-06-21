using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using Chronicle.Services.Specifications;
using Microsoft.EntityFrameworkCore;
using Chronicle.Domain.Entity;

namespace Chronicle.Services.Entity
{
    public class EntitySyncService : IEntitySyncService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        protected readonly IMapper _mapper;
        
        public EntitySyncService(IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository;    
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task<List<T>> Get<T>(ISpecification<T> specification)
            where T : Domain.Entity.Entity
        {
            return Repository<T>()!.Query.Where(specification.Criteria).ToListAsync();
        }

        public async Task<EntityEntry<T>> Add<T>(T entity)
            where T : Domain.Entity.Entity
        {
            var repo = Repository<T>()!;
            var result = await repo.Add(entity);
            await repo.SaveChanges();
            return result;
        }

        public async Task<EntityEntry<T>> Delete<T>(T entity)
            where T : Domain.Entity.Entity, new()
        {
            var repo = Repository<T>()!;
            var current = await repo.Get(entity.Id);
            if(current != null)
                return await repo.NoChange(new T());

            var result = await repo.Delete(entity);
            await repo.SaveChanges();
            return result;
        }

        public async Task<EntityEntry<T>> Merge<T>(T entity, SyncOptions options)
            where T : Domain.Entity.Entity
        {
            var repo = Repository<T>()!;
            var current = await repo.Get(entity.Id);

            if (current == null)
                return await repo.Add(entity);

            if (current.SyncTimestamp > options.CommandTimestamp)
                return await repo.NoChange(current);
        
            current = _mapper.Map<T>(entity);
            var result = repo.Update(current);
            await repo.SaveChanges();
            return result;
        }

        private IRepository<T>? Repository<T>()
            where T : Domain.Entity.Entity
        {
            if (typeof(T) == typeof(Author))
                return _authorRepository as IRepository<T>;
            else if (typeof(T) == typeof(Book))
                return _bookRepository as IRepository<T>;
            else
                throw new NotImplementedException($"the type {typeof(T)} needs a repository");
        }

    }
}