using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class ChapterRepository : EntityRepository<Chapter>
    {
        public ChapterRepository(ChronicleDbContext context) : base(context)
        {
        }
    }
}
