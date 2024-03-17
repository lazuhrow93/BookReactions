using AutoMapper;
using Chronical.App.Controllers;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private IMapper _mapper;
        private IChapterRepository _chapterRepository;

        public ChapterService(
            IChapterRepository chapterService,
            IMapper mapper)
        {
            _chapterRepository = chapterService;
            _mapper = mapper;
        }

        public bool ChapterExists(int id)
        {
            return (_chapterRepository.Get(id) != null);
        }
    }
}
