using AutoMapper;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
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

        public ActionResult AddBook(BookDto newBookDto)
        {
            var result = new ActionResult()
            {
                State = State.NotAdded,
                Errors = new()
            };

            var authorDto = newBookDto.Author;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
            if (author is null)
            {
                result.Errors.Add("The author doesn't exist for this book");
            }

            var newBook = _mapper.Map<Book>(newBookDto);
            newBook.AuthorId = author.Id;
            _bookRepository.Add(newBook);
            _bookRepository.SaveChanges();
            result.State = State.Added;
            return result;
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
