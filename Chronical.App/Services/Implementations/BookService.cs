using AutoMapper;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        private IMapper _mapper;

        public BookService(IBookRepository repo,
            IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public bool AddBook(AddBookDto newBookDto)
        {
            var newBook = _mapper.Map<Book>(newBookDto);
            _repository.Add(newBook);
            _repository.SaveChanges();
            return true;
        }

        public bool BookExists(int bookId)
        {
            if (_repository.Get(bookId) is null) return false;
            else return true;
        }
    }
}
