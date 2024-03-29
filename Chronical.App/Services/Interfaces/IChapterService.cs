using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface IChapterService
    {
        public RepositoryResult<Chapter> AddChapter(ChapterDto newChapterDto);
    }
}