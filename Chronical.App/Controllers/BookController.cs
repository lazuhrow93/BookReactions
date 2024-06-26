﻿using Chronical.App.Models.IncomingDto;
using Chronical.App.Models;
using Microsoft.AspNetCore.Mvc;
using Chronicle.Domain.Repositories;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Models.OutogingDto;
using AutoMapper;
using Chronicle.Domain.Entity;
using Chronical.App.Services.Interfaces.Old;

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

        [HttpPost]
        public ChronicleResponse<Book> AddBook(BookDto newBookDto)
        {
            var result = _bookService.AddBook(newBookDto);

            var response = new ChronicleResponse<Book>();
            response.ForAdd(result);
            return response!;
        }

        [HttpGet]
        [Route("{bookId}")]
        public ChronicleResponse<Book> GetBook(int bookId)
        {
            var result = _bookService.GetBook(bookId);

            var response = new ChronicleResponse<Book>();
            response.ForLookup(result);

            return response;
        }
    }
}
