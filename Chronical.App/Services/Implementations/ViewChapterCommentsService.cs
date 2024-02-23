using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Domain.Entity;

namespace Chronical.App.Services.Implementations
{
    public class ViewChapterCommentsService : IViewChapterCommentsService
    {
        private IRepository<Comment> _commentRepository;

        public ViewChapterCommentsService(IRepository<Comment> commentRepo)
        {
            _commentRepository = commentRepo;
        }

        public Comment[] GetCommentsForBook(int bookId, int chapterId)
        {
            return _commentRepository
                .FetchAll()
                .Where(c => c.BookId == bookId && c.ChapterId == chapterId).ToArray();
        }
    }
}
