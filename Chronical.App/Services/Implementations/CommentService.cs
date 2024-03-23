using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Domain.Entity;
using SpicyWing.Extensions;
using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Repositories;
using Chronical.App.Services.Extensions;

namespace Chronical.App.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IChapterRepository _chapterRepository;
        private IMapper _mapper;

        public CommentService(
            ICommentRepository commentRepository,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IChapterRepository chapterRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public ChapterCommentsDto UnderChapter(int chapterId)
        {
            var comments = _commentRepository
                .Query
                .Where(c => c.ChapterId == chapterId).ToArray();

            var noComments = comments.IsNullOrEmpty();

            return new ChapterCommentsDto()
            {
                Comments = (noComments) ? Enumerable.Empty<string>() : comments.Select(c => c.Value!),
                Message = (noComments) ? "No Comments Yet!" : ""
            };
        }

        public ActionResult<Comment> AddComment(CommentDto newComment)
        {
            var authorDto = newComment.Chapter.Book!.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
            var result = new ActionResult<Comment>()
            {
                State = State.NotAdded,
                Errors = new()
            };

            if (author is null)
            {
                result.Errors.Add("The author doesn't exist for this book");
                return result;
            }

            var books = _bookRepository.FindBookByAuthorAndTitle(author.Id, newComment.Chapter.Book.Title!);
            if(books.Any())
            {
                result.Errors.Add("The book doesn't exist under this author");
                return result;
            }

            var book = books.First();
            var chapter = _chapterRepository.GetByBookAndNumber(book.Id, newComment.Chapter.ChapterNumber);
            if(chapter is null)
            {
                result.Errors.Add("The chapter doesn't exist for this book");
                return result;
            }


            var newCommentEntity = _mapper.Map<Comment>(newComment);
            newCommentEntity.BookId = book.Id;
            newCommentEntity.ChapterId = chapter.Id;
            newCommentEntity.LastUpdate = DateTime.UtcNow;
            _commentRepository.Add(newCommentEntity);
            result.Entity = newCommentEntity;
            result.State = State.Added;
            return result;
        }
    }
}
