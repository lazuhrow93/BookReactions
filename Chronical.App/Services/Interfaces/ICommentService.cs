using Chronical.App.Controllers;
using Chronical.App.Models;
using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentService
    {
        public ActionResult<Comment> AddComment(CommentDto newComment);
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
