using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private IChapterRepository chapterRepository;

        public ChapterService(IChapterRepository chapterService)
        {
            chapterRepository = chapterService;
        }

        public bool ChapterExists(int id)
        {
            return (chapterRepository.Get(id) != null);
        }
    }
}
