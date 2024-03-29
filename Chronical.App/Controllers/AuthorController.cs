using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces;
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
        [Route("author")]
        public ChronicleResponse<object> AddAuthor(AuthorDto dto)
        {
            var response = new ChronicleResponse<object>();
            var result = _authorService.AddAuthor(dto);

            response.Success = result.EntityAdded;
            response.Error = result.Errors.ToArray();
            response.Data = result.Entity;
            return response;
        }

        [HttpGet]
        [Route("author")]
        public ChronicleResponse<object> Get([FromQuery] AuthorDto dto)
        {
            var response = new ChronicleResponse<object>();
            var result = _authorService.GetAuthor(dto);
            response.Success = result.EntityFound;
            response.Data = result.Entity;
            response.Error = result.Errors.ToArray();

            return response;
        }
    }
}
