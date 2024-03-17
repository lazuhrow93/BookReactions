using Chronical.App.Controllers;
using Chronical.Domaion.FrontEnd;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentsService
    {
        public void AddComment(AddCommentsDto newComment, int bookId, int chapterId);
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
