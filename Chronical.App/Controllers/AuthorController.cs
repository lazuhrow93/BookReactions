using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthorController
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService service)
        {
            _authorService = service; 
        }

        [HttpPost]
        public ChronicleResponse<Author> AddAuthor(AuthorDto dto)
        {
            var result = _authorService.AddAuthor(dto);

            var response = new ChronicleResponse<Author>();
            response.ForAdd(result);
            return response;
        }

        [HttpGet]
        public ChronicleResponse<Author> Get([FromQuery] AuthorDto dto)
        {
            var result = _authorService.GetAuthor(dto);

            var response = new ChronicleResponse<Author>();
            response.ForLookup(result);
            return response;
        }
    }
}
