using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface IChapterService
    {
        public ActionResult AddChapter(ChapterDto newChapterDto);
        public Chapter? GetChapter(int id, ChapterDto chapter);
    }
}