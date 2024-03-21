using Chronical.App.Controllers;
using Chronical.App.Models;
using Chronical.App.Models.Dto;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentService
    {
        public ActionResult AddComment(CommentDto newComment);
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
