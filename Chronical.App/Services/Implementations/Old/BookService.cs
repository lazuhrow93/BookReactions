using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutogingDto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations.Old
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

        public RepositoryResult<Book> AddBook(BookDto newBookDto)
        {
            var result = new RepositoryResult<Book>();
            result.SetState(State.NotAdded);

            var authorDto = newBookDto.AuthorId;
            var author = _authorRepository.Get(newBookDto.AuthorId);
            if (author is null)
            {
                result.Errors.Add(string.Format("The author {0} doesn't exist", newBookDto.AuthorId));
                return result;
            }

            var newBook = _mapper.Map<Book>(newBookDto);
            newBook.AuthorId = author.Id;
            _bookRepository.Add(newBook);
            _bookRepository.SaveChanges();
            result.Entity = newBook;
            result.SetState(State.Added);
            return result;
        }

        public RepositoryResult<Book> GetBook(int bookId)
        {
            var result = new RepositoryResult<Book>();
            result.SetState(State.NotFound);

            var bookFromDb = _bookRepository.Get(bookId);
            if (bookFromDb is null)
            {
                result.AddError("Unable to find that book");
                return result;
            }

            result.SetState(State.Found);
            result.Entity = bookFromDb;
            return result;
        }
    }
}
