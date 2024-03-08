using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Domain.Entity;
using Chronical.Domaion.FrontEnd;

namespace Chronical.App.Services.Implementations
{
    public class CommentsService : ICommentsService
    {
        private ICommentRepository _commentRepository;

        public CommentsService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public ChapterCommentsDto UnderChapter(int chapterId)
        {
            var comments = _commentRepository
                .FetchAll()
                .Select(c => c.ChapterId == chapterId).ToArray();

            if (comments.IsNullOrEmpty())
                throw new NotImplementedException("there are not comments under this chapter, do something about it!");
            
            return new ChapterCommentsDto()
            {
                Comments = comments.Select(c => c.CommentLiteral!) ?? Enumerable.Empty<string>()
            };
        }
    }
}
