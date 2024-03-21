using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronical.App.Models.Dto;
using Chronical.App.Models;
using Chronicle.Domain.Entity;

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

        [HttpPost(Name = "comment")]
        public ChronicleResponse AddCommentToChapter(CommentDto newComment)
        {
            var response = new ChronicleResponse();
            var errors = new List<string>();
            var codes = new List<ErrorCode>();

            var book = _bookService.GetBook(newComment.Chapter.Book!);
            if (book is null)
            {
                errors.Add("The book doesnt exist");
                codes.Add(ErrorCode.BookDoesNotExist);
                errors.Add("The chapter doesn't exist");
                codes.Add(ErrorCode.ChapterDoesNotExist);
            }
            else
            {
                var chapter = _chapterService.GetChapter(book.Id, newComment.Chapter);
                if (chapter is null)
                {
                    errors.Add("The chapter doesn't exist");
                    codes.Add(ErrorCode.ChapterDoesNotExist);
                }
                else
                {
                    var added = _commentsService.AddComment(newComment, book.Id, chapter.Id);
                    if (!added)
                    {
                        errors.Add("Unable to add this comment to that chapter/book");
                        codes.Add(ErrorCode.CouldNtAddComment);
                    }
                }

            }

            response.Success = (errors.Any() == false);
            response.Error = errors.ToArray();
            response.Code = codes.ToArray();
            return response;
        }
    }
}
