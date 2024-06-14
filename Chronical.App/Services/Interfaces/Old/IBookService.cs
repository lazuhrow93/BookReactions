using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutogingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Chronical.App.Services.Interfaces.Old
{
    public interface IBookService
    {
        public RepositoryResult<Book> AddBook(BookDto newBookDto);
        public RepositoryResult<Book> GetBook(int bookId);
    }
}
