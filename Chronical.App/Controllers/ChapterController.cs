using Chronical.App.Models;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
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
        public ChronicleResponse<Chapter> AddChapter(ChapterDto newChapter)
        {
            var result = _chapterService.AddChapter(newChapter);

            var response = new ChronicleResponse<Chapter>();
            response.ForAdd(result);
            
            return response;
        }
    }
}
