using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Services.Interfaces
{
    public interface IChapterService
    {
        public bool AddChapter(ChapterDto newChapterDto, int bookId);
        public Chapter? GetChapter(int id, ChapterDto chapter);
    }
}