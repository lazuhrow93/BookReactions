using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class ChapterRepository : IChapterRepository
    {
        private ChronicleDBContext _context { get; set; }

        public IQueryable<Chapter> Query
        {
            get { return _context.Set<Chapter>().AsQueryable(); }
        }

        public ChapterRepository(ChronicleDBContext context)
        {
            _context = context;
        }

        public Chapter Add(Chapter entity)
        {
            _context.Add(entity);
            return entity;
        }

        public IEnumerable<Chapter> Add(IEnumerable<Chapter> entities)
        {
            _context.AddRange(entities);
            return entities;
        }

        public void Delete(Chapter entities)
        {
            _context.Remove(entities);
        }

        public void Delete(IEnumerable<Chapter> entities)
        {
            _context.RemoveRange(entities);
        }

        public Chapter? Get(int id)
        {
            return Query.Where(c => c.Id == id).FirstOrDefault();   
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Chapter Update(Chapter entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
