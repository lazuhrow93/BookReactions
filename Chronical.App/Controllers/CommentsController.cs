using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronical.App.Models.Dto;
using Chronical.App.Models;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController
    {
        ICommentsService _commentsService;
        IChapterService _chapterService;
        IBookService _bookService;

        public CommentsController(
            ICommentsService commentsService,
            IChapterService chapterService,
            IBookService bookService)
        {
            _bookService = bookService;
            _chapterService = chapterService;
            _commentsService = commentsService;
        }

        [HttpGet(Name = "comments/{id}")]
        public ChapterCommentsDto Get(int chapterId)
        {
            var result = _commentsService.UnderChapter(chapterId);
            return _commentsService.UnderChapter(chapterId);
        }

        [HttpPost(Name = "comment/{bookId}/{chapterId}")]
        public ChronicleResponse AddCommentToChapter(int bookId, int chapterId, AddCommentsDto newComment)
        {
            var response = new ChronicleResponse();
            var errors = new List<string>();
            var codes = new List<ErrorCode>();
            
            if (!_bookService.BookExists(bookId))
            {
                errors.Add("The book doesnt exist");
                codes.Add(ErrorCode.BookDoesNotExist);
            }
            
            if (!_chapterService.ChapterExists(chapterId))
            {
                errors.Add("The chapter doesn't exist");
                codes.Add(ErrorCode.ChapterDoesNotExist);
            }

            if (errors.Any() == false)
            {
                var added = _commentsService.AddComment(newComment, bookId, chapterId);
                if (!added)
                {
                    errors.Add("Unable to add this comment to that chapter/book");
                    codes.Add(ErrorCode.CouldNtAddComment);
                }
            }

            response.Success = (errors.Any() == false);
            response.Error = errors.ToArray();
            response.Code = codes.ToArray();
            return response;
        }
    }
}
