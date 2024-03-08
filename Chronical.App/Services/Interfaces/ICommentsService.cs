using Chronical.Domaion.FrontEnd;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentsService
    {
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
