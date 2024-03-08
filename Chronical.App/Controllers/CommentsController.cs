using Chronical.App.Services.Interfaces;
using Chronical.Domaion.FrontEnd;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController
    {
        ICommentsService _commentsService;
        IChapterService _chapterService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet(Name = "chapter/{id}")]
        public ChapterCommentsDto Get(int chapterId)
        {
            return _commentsService.UnderChapter(chapterId);
        }
    }
}
