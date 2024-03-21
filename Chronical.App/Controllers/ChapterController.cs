using Chronical.App.Models;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ChapterController
    {
        public IChapterService _chapterService;
        public IBookService _bookService;

        public ChapterController(IChapterService chapterService,
            IBookService bookService)
        {
            _chapterService = chapterService;
            _bookService = bookService;

        }

        [HttpPost(Name = "chapter")]
        public ChronicleResponse AddChapter(ChapterDto newChapter)
        {
            var response = new ChronicleResponse();
            var errors = new List<string>();
            var codes = new List<ErrorCode>();

            var book = _bookService.GetBook(newChapter.Book!);
            if (book is null)
            {
                errors.Add("Unable to add the chapter because the book doesn't exist");
                codes.Add(ErrorCode.BookDoesNotExist);
            }
            else
            {
                var added = _chapterService.AddChapter(newChapter, book.Id);
                if (!added)
                {
                    errors.Add("Unable to add that chapter for unknown reasons");
                    codes.Add(ErrorCode.CouldNotAddChapter);
                }
            }
            response.Success = errors.Any() == false;
            response.Error = errors.ToArray();
            response.Code = codes.ToArray();
            return response;
        }
    }
}
