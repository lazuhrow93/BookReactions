using Chronical.App.Models.Dto;
using Chronical.App.Models;
using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronicle.Domain.Repositories;

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
        public ChronicleResponse AddBook(BookDto newBookDto)
        {
            var response = new ChronicleResponse();

            var result = _bookService.AddBook(newBookDto);

            response.Success = (result.State == State.Added);
            response.Error = result.Errors!.ToArray();
            return response;
        }
    }
}
