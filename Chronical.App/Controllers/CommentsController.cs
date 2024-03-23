using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models;
using Chronicle.Domain.Repositories;
using Chronical.App.Models.OutgoingDto;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController
    {
        ICommentService _commentService;
        IChapterService _chapterService;
        IBookService _bookService;

        public CommentsController(
            ICommentService commentsService,
            IChapterService chapterService,
            IBookService bookService)
        {
            _bookService = bookService;
            _chapterService = chapterService;
            _commentService = commentsService;
        }

        [HttpGet(Name = "comments/{id}")]
        public ChapterCommentsDto Get(int chapterId)
        {
            var result = _commentService.UnderChapter(chapterId);
            return _commentService.UnderChapter(chapterId);
        }

        [HttpPost(Name = "comment")]
        public ChronicleResponse<object> AddCommentToChapter(CommentDto newComment)
        {
            var response = new ChronicleResponse<object>();
            var errors = new List<string>();

            //TODO: CommentDto - Validation

            var result = _commentService.AddComment(newComment);

            response.Success = (result.State == State.Added);
            response.Error = result.Errors!.ToArray();
            return response;
        }
    }
}
