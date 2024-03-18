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

        [HttpPost(Name = "chapter/{bookId}")]
        public ChronicleResponse AddChapter(int bookId, AddChapterDto newChapter)
        {
            var response = new ChronicleResponse();
            var errors = new List<string>();
            var codes = new List<ErrorCode>();

            if (_bookService.BookExists(bookId) == false)
            {
                errors.Add("Unable to add the chapter because the book doesn't exist");
                codes.Add(ErrorCode.BookDoesNotExist);
            }
            else
            {
                var added = _chapterService.AddChapter(newChapter);
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

    public class AddChapterDto
    {
        public string? Title { get; set; }
        public int Number { get; set; }
        public string BookTitle { get; set; }
    }
}
