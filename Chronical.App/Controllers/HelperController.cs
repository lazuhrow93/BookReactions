using Chronical.App.Helper;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HelperController
    {
        private Seed _dataSeeder;

        public HelperController(
            IAuthorService authorService,
            IBookService bookSerivce,
            IChapterService chapterService,
            ICharacterService characterService,
            ICommentService commentService)
        {
            _dataSeeder = new(authorService, bookSerivce, chapterService, characterService, commentService);
        }

        [HttpGet]
        public void Seed()
        {
            _dataSeeder.SeedBasicData();
        }
    }
}
