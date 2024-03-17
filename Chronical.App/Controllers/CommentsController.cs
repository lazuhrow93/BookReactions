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

        [HttpGet(Name = "chapter/{id}")]
        public ChapterCommentsDto Get(int chapterId)
        {
            var result = _commentsService.UnderChapter(chapterId);
            return _commentsService.UnderChapter(chapterId);
        }

        [HttpPost(Name = "chapter/{bookId}/{chapterId}")]
        public bool AddCommentToChapter(int bookId, int chapterId, AddCommentsDto newComment)
        {
            if (!_bookService.BookExists(bookId))
                throw new Exception($"Book doesn't exist");
            if (!_chapterService.ChapterExists(chapterId))
                throw new Exception($"Chapter doesnt exist in book {bookId}");

            _commentsService.AddComment(newComment, bookId, chapterId);
            return true;
        }
    }
}
