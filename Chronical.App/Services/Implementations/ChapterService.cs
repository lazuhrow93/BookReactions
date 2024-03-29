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

        public RepositoryResult<Chapter> AddChapter(ChapterDto newChapterDto)
        {
            var result = new RepositoryResult<Chapter>();
            result.SetState(State.NotAdded);

            var authorDto = newChapterDto.Book!.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);

            if(author == null)
            {
                result.SetState(State.NotFound);
                result.AddError("The author doesnt exist for this chapter");
                return result;
            }

            var bookDto = newChapterDto.Book;
            var book = _bookRepository.FindBookByAuthorAndTitle(author!.Id, bookDto.Title!);
            if(book.Any() == false)
            {
                result.SetState(State.NotFound);
                result.AddError("The book doesnt exist for this chapter");
                return result;
            }

            var newChapter = _mapper.Map<Chapter>(newChapterDto);
            newChapter.BookId = book.First().Id;

            var entityEntry = _chapterRepository.Add(newChapter);
            _chapterRepository.SaveChanges();

            if (entityEntry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                result.SetState(State.Added);
                result.Entity = entityEntry.Entity;
            }
            else
            {
                result.SetState(State.NotAdded);
                result.AddError("Unable to add the chapter for unknown reason");
            }

            return result;
        }
    }
}
