using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;
using SpicyWing.Extensions;

namespace Chronical.App.Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private IMapper _mapper;
        private IChapterRepository _chapterRepository;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;


        public ChapterService(
            IChapterRepository chapterRepository,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public ActionResult<Chapter> AddChapter(ChapterDto newChapterDto)
        {
            var result = new ActionResult<Chapter>()
            {
                State = State.NotAdded,
                Errors = new(),
                Entity = null
            };

            var authorDto = newChapterDto.Book!.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);

            if(author == null)
            {
                result.State = State.NotFound;
                result.Errors.Add("The author doesnt exist for this chapter");
                return result;
            }

            var bookDto = newChapterDto.Book;
            var book = _bookRepository.FindBookByAuthorAndTitle(author!.Id, bookDto.Title!);
            if(book.Any() == false)
            {
                result.State = State.NotFound;
                result.Errors.Add("The book doesnt exist for this chapter");
                return result;
            }

            var newChapter = _mapper.Map<Chapter>(newChapterDto);
            newChapter.BookId = book.First().Id;

            var entityEntry = _chapterRepository.Add(newChapter);
            _chapterRepository.SaveChanges();

            if(entityEntry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                result.State = State.Added;
                result.Entity = entityEntry.Entity;
            }
            else
            {
                result.State = State.NotAdded;
                result.Errors.Add("Unable to add the chapter for unknown reason");
            }

            return result;
        }
    }
}
