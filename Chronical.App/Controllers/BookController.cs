using Chronical.App.Models.IncomingDto;
using Chronical.App.Models;
using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronicle.Domain.Repositories;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Models.OutogingDto;
using AutoMapper;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public partial class BookController
    {
        private IBookService _bookService;
        private IMapper _mapper;

        public BookController(IBookService bookservice, IMapper mapper)
        {
            _mapper = mapper;
            _bookService = bookservice;
        }

        [HttpPost("Book")]
        public ChronicleResponse<object?> AddBook(BookDto newBookDto)
        {
            var response = new ChronicleResponse<object>();

            var result = _bookService.AddBook(newBookDto);

            response.Data = null;
            response.Success = result.EntityAdded;
            response.Error = result.Errors!.ToArray();
            return response!;
        }

        [HttpPost("GetBook")]
        public ChronicleResponse<BookDetailsDto> GetBook(BookDto book)
        {
            var response = new ChronicleResponse<BookDetailsDto>();

            var result = _bookService.GetBook(book);
            response.Success = result.EntityFound;
            response.Error = result.Errors!.ToArray();
            response.Data = _mapper.Map<BookDetailsDto>(result.Entity);
            return response;
        }
    }
}
