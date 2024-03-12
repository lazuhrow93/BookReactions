using Chronical.App.Services.Interfaces;
using Chronical.Domaion.FrontEnd;
using Microsoft.AspNetCore.Mvc;
using CommonLibrary.Extensions;

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
            var result = _commentsService.UnderChapter(chapterId);
            return _commentsService.UnderChapter(chapterId);
        }

        [HttpPost(Name = "chapter/{id}")]
        public bool AddCommentToChapter(int chapterId, AddCommentsDto newComment)
        {
            
        }
    }
}
