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

        public RepositoryResult<Book> AddBook(BookDto newBookDto)
        {
            var result = new RepositoryResult<Book>();
            result.SetState(State.NotAdded);

            var authorDto = newBookDto.Author;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
            if (author is null)
            {
                result.Errors.Add("The author doesn't exist");
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

        public RepositoryResult<Book> GetBook(BookDto book)
        {
            var result = new RepositoryResult<Book>();
            result.SetState(State.NotFound);

            var authorDto = book.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
             
            if(author is null)
            {
                result.AddError("Unable to find that author");
                return result;
            }

            var bookFromDb = _bookRepository.FindBookByAuthorAndTitle(author.Id, book.Title!);
            if (bookFromDb.Any() == false)
            {
                result.SetState(State.NotFound);
                result.AddError("Unable to find that book");
                return result;
            }

            result.SetState(State.Found);
            result.Entity = bookFromDb.First();
            return result;
        }
    }
}
