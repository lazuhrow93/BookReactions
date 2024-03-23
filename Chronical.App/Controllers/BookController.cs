using Chronical.App.Models.IncomingDto;
using Chronical.App.Models;
using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronicle.Domain.Repositories;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Models.OutogingDto;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public partial class BookController
    {
        private IBookService _bookService;

        public BookController(IBookService bookservice)
        {
            _bookService = bookservice;
        }

        [HttpPost("book")]
        public ChronicleResponse<object?> AddBook(BookDto newBookDto)
        {
            var response = new ChronicleResponse<object>();

            var result = _bookService.AddBook(newBookDto);

            response.Data = null;
            response.Success = (result.State == State.Added);
            response.Error = result.Errors!.ToArray();
            return response;
        }

        [HttpGet("book")]
        public ChronicleResponse<BookDetailsDto> GetBook(BookDto book)
        {
            var response = new ChronicleResponse<BookDetailsDto>();

            var result = _bookService.GetBook(book);
            response.Success = (result.State == State.Found);
            response.Error = result.Errors!.ToArray();
            response.Data = result.Entity;
            return response;
        }
    }
}
