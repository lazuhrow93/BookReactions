using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutogingDto;
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

        public ActionResult<Book> AddBook(BookDto newBookDto)
        {
            var result = new ActionResult<Book>()
            {
                State = State.NotAdded,
                Errors = new(),
                Entity = null
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
            result.Entity = newBook;
            result.State = State.Added;
            return result;
        }

        public ActionResult<BookDetailsDto> GetBook(BookDto book)
        {
            var result = new ActionResult<BookDetailsDto>()
            {
                State = State.NotFound,
                Errors = new List<string>(),
                Entity = null
            };

            var authorDto = book.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
             
            if(author is null)
            {
                result.Errors.Add("Unable to find that author");
                return result;
            }

            var bookFromDb = _bookRepository.FindBookByAuthorAndTitle(author.Id, book.Title!);
            if (bookFromDb.Any())
            {
                var details = _mapper.Map<BookDetailsDto>(bookFromDb.First());
                details.Author = string.Format("{firstName} {middleName} {LastName}", author.FirstName, author.MiddleName, author.LastName);
                result.State = State.Found;
                result.Entity = details;
            }

            return result;
        }
    }
}
