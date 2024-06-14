using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;
using SpicyWing.Extensions;

namespace Chronical.App.Services.Implementations.Old
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

            var book = _bookRepository.Get(newChapterDto.BookId);
            if (book is null)
            {
                result.SetState(State.NotFound);
                result.AddError("The book doesnt exist for this chapter");
                return result;
            }

            var newChapter = _mapper.Map<Chapter>(newChapterDto);

            var entityEntry = _chapterRepository.Add(newChapter);

            if (entityEntry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                result.SetState(State.Added);
                result.Entity = entityEntry.Entity;
                _chapterRepository.SaveChanges();
            }
            else
            {
                result.SetState(State.NotAdded);
                result.AddError("Unable to add the chapter for unknown reason");
            }

            return result;
        }

        public RepositoryResult<IEnumerable<Chapter>> AddChapter(IEnumerable<ChapterDto> newChapterDtos)
        {
            var result = new RepositoryResult<IEnumerable<Chapter>>();
            result.SetState(State.NotAdded);

            var newChapter = _mapper.Map<List<Chapter>>(newChapterDtos);

            var entityEntries = _chapterRepository.Add(newChapter);

            if (entityEntries.All(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added))
            {
                result.SetState(State.Added);
                result.Entity = entityEntries.Select(e => e.Entity).AsEnumerable();
                _chapterRepository.SaveChanges();
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
