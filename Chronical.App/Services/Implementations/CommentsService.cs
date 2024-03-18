using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Domain.Entity;
using CommonLibrary.Extensions;
using AutoMapper;
using Chronical.App.Models.Dto;

namespace Chronical.App.Services.Implementations
{
    public class CommentsService : ICommentsService
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public CommentsService(
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
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

        public bool AddComment(AddCommentsDto newComment, int bookId, int chapterId)
        {
            var newCommentEntity = _mapper.Map<Comment>(newComment);
            newCommentEntity.BookId = bookId;
            newCommentEntity.ChapterId = chapterId;
            newCommentEntity.LastUpdate = DateTime.UtcNow;
            _commentRepository.Add(newCommentEntity);
            return true;
        }
    }
}
