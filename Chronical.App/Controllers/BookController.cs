using Chronical.App.Models.Dto;
using Chronical.App.Models;
using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class BookController
    {
        private IBookService _bookService;

        public BookController(IBookService bookservice)
        {
            _bookService = bookservice;
        }

        [HttpPost("book")]
        public ChronicleResponse AddBook(AddBookDto newBookDto)
        {
            var response = new ChronicleResponse();
            var added = _bookService.AddBook(newBookDto);
            response.Success = added;
            response.Error = (!added) ? new string[] { "Unable to add that book" } : null;
            response.Code = (!added) ? new ErrorCode[] { ErrorCode.CouldNotAddBook } : null;
            return response;
        }
    }
}
