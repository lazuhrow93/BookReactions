using Chronical.App.Controllers;
using Chronical.App.Models;
using Chronical.App.Models.Dto;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentsService
    {
        public bool AddComment(AddCommentsDto newComment, int bookId, int chapterId);
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
