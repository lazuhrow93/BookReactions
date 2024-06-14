using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController
    {
        private ICharacterService _characterService;

        public CharacterController(ICharacterService service)
        {
            _characterService = service;
        }

        [HttpGet]
        [Route("book/{bookId}")]
        public ChronicleResponse<List<Character>> GetCharacters(int bookId)
        {
            var repoResult = _characterService.GetAllCharactersByBook(bookId);

            var response = new ChronicleResponse<List<Character>>();
            response.ForLookup(repoResult);
            return response;
        }

        [HttpPost]
        public ChronicleResponse<Character> AddCharacter(CharacterDto dto)
        {
            var repoResult = _characterService.AddCharacter(dto);

            var response = new ChronicleResponse<Character>();
            response.ForAdd(repoResult);
            return response;
        }
    }
}
