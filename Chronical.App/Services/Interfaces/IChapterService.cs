using Chronical.App.Controllers;

namespace Chronical.App.Services.Interfaces
{
    public interface IChapterService
    {
        public bool AddChapter(AddChapterDto newChapterDto);
        public bool ChapterExists(int id);
    }
}