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

        public bool AddComment(AddCommentsDto newComment)
        {
            var chapter = newComment.ChapterId;

        }
    }
}
