using Chronical.App.Helper;
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
           IAuthorRepository authorRepository,
           IBookRepository bookRepository,
           IChapterRepository chapterRepository,
           ICharacterRepository characterRepository,
           ICommentRepository commentRepository)
        {
            _dataSeeder = new(authorRepository, bookRepository, chapterRepository, characterRepository, commentRepository);
        }

        [HttpGet]
        public void Seed()
        {
            _dataSeeder.SeedBasicData();
        }
    }
}
