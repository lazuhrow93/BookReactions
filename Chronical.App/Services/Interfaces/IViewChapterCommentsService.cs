using System;
namespace Chronical.App.Services.Interfaces
{
    public interface IViewChapterCommentsService
    {
        public void GetCommentsForBook(int bookId, int chapterId); 
    }
}
