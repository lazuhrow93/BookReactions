using Chronical.App.Models;
using Chronical.App.Models.Dto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories;
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

            var result = _chapterService.AddChapter(newChapter);

            response.Success = result.State == State.Added;
            response.Error = result.Errors!.ToArray();
            return response;
        }
    }
}
