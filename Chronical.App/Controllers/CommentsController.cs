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

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet(Name = "chapter/{id}")]
        public ChapterCommentsDto Get(int chapterId)
        {
            var comments = new List<ChapterCommentsDto>();

            return _commentsService.UnderChapter(chapterId);
        }
    }
}
