using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Interfaces
{
    public interface IBookService
    {
        public bool BookExists(int bookId);
    }

    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repo)
        {
            _repository = repo;
        }

        public bool BookExists(int bookId)
        {
            return _repository.Get(bookId) is null;
        }
    }
}
