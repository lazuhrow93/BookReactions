using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public interface IChapterRepository : IRepository<Chapter>
    {
        public bool ChapterExists(int id);
    }
}
