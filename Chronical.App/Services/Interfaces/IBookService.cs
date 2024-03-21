using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface IBookService
    {
        public ActionResult AddBook(BookDto newBookDto);
    }
}
