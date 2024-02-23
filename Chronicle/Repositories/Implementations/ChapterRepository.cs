using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class ChapterRepository : IRepository<Chapter>
    {
        public Chapter Get(int id)
        {
            throw new NotImplementedException("IMPLEMENT DB TO GET CHAPTER");
        }

        public IQueryable<Chapter> FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
