using AutoMapper;
using Chronical.App.Models.Dto;
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

        public ActionResult AddChapter(ChapterDto newChapterDto)
        {
            var result = new ActionResult()
            {
                State = State.NotAdded,
                Errors = new()
            };

            var authorDto = newChapterDto.Book!.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);

            if(author == null)
            {
                result.Errors.Add("The author doesnt exist for this chapter");
            }

            var bookDto = newChapterDto.Book;
            var book = _bookRepository.FindBookByAuthorAndTitle(author.Id, bookDto.Title);
            if(book == null)
            {
                result.Errors.Add("The book doesnt exist for this chapter");
            }

            var newChapter = _mapper.Map<Chapter>(newChapterDto);
            newChapter.BookId = book.Id;

            _chapterRepository.Add(newChapter);
            _chapterRepository.SaveChanges();
            result.State = State.Added;
            return result;
        }
    }
}
