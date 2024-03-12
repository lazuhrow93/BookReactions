using Chronicle.Domain.Entity;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        public IQueryable<Book> books { get; }
    }
}