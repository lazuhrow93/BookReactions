using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IChapterRepository : IRepository<Chapter>
    {
        public IQueryable<Chapter> chapters { get; }
    }
}
