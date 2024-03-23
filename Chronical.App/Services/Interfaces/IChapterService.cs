using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface IChapterService
    {
        public ActionResult<Chapter> AddChapter(ChapterDto newChapterDto);
    }
}