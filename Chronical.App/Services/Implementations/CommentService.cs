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

        public RepositoryResult<Comment> AddComment(CommentDto newComment)
        {
            var authorDto = newComment.Chapter.Book!.Author!;
            var author = _authorRepository.GetByFullName(authorDto.FirstName!, authorDto.MiddleName!, authorDto.LastName!);
            var result = new RepositoryResult<Comment>();
            result.SetState(State.NotAdded);

            if (author is null)
            {
                result.AddError("The author doesn't exist for this book");
                result.SetState(State.NotAdded);
                return result;
            }

            var books = _bookRepository.FindBookByAuthorAndTitle(author.Id, newComment.Chapter.Book.Title!);
            if(books.Any())
            {
                result.AddError("The book doesn't exist under this author");
                result.SetState(State.NotAdded);
                return result;
            }

            var book = books.First();
            var chapter = _chapterRepository.GetByBookAndNumber(book.Id, newComment.Chapter.ChapterNumber);
            if(chapter is null)
            {
                result.AddError("The chapter doesn't exist for this book");
                result.SetState(State.NotAdded);
                return result;
            }


            var newCommentEntity = _mapper.Map<Comment>(newComment);
            newCommentEntity.BookId = book.Id;
            newCommentEntity.ChapterId = chapter.Id;
            _commentRepository.Add(newCommentEntity);
            _commentRepository.SaveChanges();
            result.Entity = newCommentEntity;
            result.SetState(State.Added);
            return result;
        }
    }
}
