using AutoMapper;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
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

        public bool AddChapter(ChapterDto newChapterDto, int bookId)
        {
            var newChapter = _mapper.Map<Chapter>(newChapterDto);
            newChapter.BookId = bookId;

            _chapterRepository.Add(newChapter);
            _chapterRepository.SaveChanges();
            return true;
        }

        public bool ChapterExists(int id)
        {
            return (_chapterRepository.Get(id) != null);
        }

        public Chapter? GetChapter(int bookId, ChapterDto chapter)
        {
            var book = _bookRepository.Get(bookId);
            if (book == null) return null;

            return _chapterRepository.GetByBookAndNumber(book.Id, chapter.ChapterNumber);
        }
    }
}
