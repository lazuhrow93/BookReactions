using AutoMapper;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IMapper _mapper;

        public BookService(IBookRepository repo,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _bookRepository = repo;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public bool AddBook(BookDto newBookDto)
        {
            var authorDto = newBookDto.Author;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
            if (author is null) return false; //need to add author first


            var existingBook = _bookRepository.FindBookByAuthorAndTitle(author.Id, newBookDto.Title!);
            if (existingBook is not null) return false; //a book with this title already exists


            var newBook = _mapper.Map<Book>(newBookDto);
            _bookRepository.Add(newBook);
            _bookRepository.SaveChanges();
            return true;
        }

        public Book? GetBook(BookDto book)
        {
            var authorDto = book.Author;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);

            if (author is null) return null;

            return (_bookRepository.FindBookByAuthorAndTitle(author.Id, book.Title!));
        }
    }
}
