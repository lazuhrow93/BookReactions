using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Domain.Entity;
using Chronical.Domaion.FrontEnd;
using CommonLibrary.Extensions;
using Chronical.App.Controllers;
using AutoMapper;

namespace Chronical.App.Services.Implementations
{
    public class CommentsService : ICommentsService
    {
        private ICommentRepository _commentRepository;
        private IChapterRepository _chapterRepositor;
        private IBookRepository _bookRepository;
        private IMapper _mapper;

        public CommentsService(
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            mapper = mapper;
        }

        public ChapterCommentsDto UnderChapter(int chapterId)
        {
            var comments = _commentRepository
                .comments
                .Where(c => c.ChapterId == chapterId).ToArray();

            var noComments = comments.IsNullOrEmpty();

            return new ChapterCommentsDto()
            {
                Comments = (noComments) ? Enumerable.Empty<string>() : comments.Select(c => c.Value!),
                Message = (noComments) ? "No Comments Yet!" : ""
            };
        }

        public void AddComment(AddCommentsDto newComment, int bookId, int chapterId)
        {
            var newCommentEntity = _mapper.Map<Comment>(newComment);
            newCommentEntity.BookId = bookId;
            newCommentEntity.ChapterId = chapterId;
            newCommentEntity.LastUpdate = DateTime.UtcNow;
            _commentRepository.Add(newCommentEntity);
        }
    }
}
