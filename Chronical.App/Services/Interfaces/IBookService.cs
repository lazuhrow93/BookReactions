using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Services.Interfaces
{
    public interface IBookService
    {
        public bool AddBook(BookDto newBookDto);
        public Book? GetBook(BookDto book);
    }
}
