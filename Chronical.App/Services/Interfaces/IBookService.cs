using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutogingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface IBookService
    {
        public RepositoryResult<Book> AddBook(BookDto newBookDto);
        public RepositoryResult<Book> GetBook(BookDto book);
    }
}
