using Chronical.App.Models.Dto;

namespace Chronical.App.Services.Interfaces
{
    public interface IBookService
    {
        public bool AddBook(AddBookDto newBookDto);
        public bool BookExists(int bookId);
    }
}
