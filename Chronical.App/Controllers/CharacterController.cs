using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces;
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
        public ChronicleResponse<List<Character>> GetCharacters([FromQuery] CharacterDto dto)
        {
            var response = new ChronicleResponse<List<Character>>();

            var repoResult = _characterService.GetCharacters(dto);

            response.Success = repoResult.EntityFound;
            response.Error = repoResult.Errors.ToArray();
            response.Data = repoResult.Entity;

            return response;
        }

        [HttpGet]
        [Route("book")]
        public ChronicleResponse<List<Character>> GetAllForBook([FromQuery] int bookid)
        {
            var response = new ChronicleResponse<List<Character>>();

            var result = _characterService.GetAllCharactersByBook(bookid);

            if(result.EntityFound == false)
            {
                if (response.Error?.Any() == true) response.Success = !(response.Error?.Any() == true);
            }
            else
            {
                response.Success = true;
            }

            response.Error = result.Errors.ToArray();
            response.Data = result.Entity;
            return response;
        }

        [HttpPost]
        public ChronicleResponse<Character> AddCharacter(CharacterDto dto)
        {
            var response = new ChronicleResponse<Character>();

            var repoResult = _characterService.AddCharacter(dto);

            response.Success = repoResult.EntityAdded;
            response.Error = repoResult.Errors.ToArray();
            response.Data = repoResult.Entity;

            return response;
        }
    }
}
