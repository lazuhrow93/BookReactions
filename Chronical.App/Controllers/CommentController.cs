using Chronical.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models;
using Chronicle.Domain.Repositories;
using Chronical.App.Models.OutgoingDto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController
    {
        ICommentService _commentService;

        public CommentController(
            ICommentService commentsService)
        {
            _commentService = commentsService;
        }

        [HttpGet]
        [Route("character/{characterId}")]
        public ChronicleResponse<List<Comment>> GetCommentsForCharacter(int characterId)
        {
            var serviceResult = _commentService.GetAllCharacterComments(characterId);

            var response = new ChronicleResponse<List<Comment>>();
            response.ForLookup(serviceResult);

            return response;
        }

        [HttpPost]
        [Route("book/character")]
        public ChronicleResponse<Comment> AddCommentForCharacter(CommentDto newComment)
        {
            var serviceResult = _commentService.AddCommentForCharacter(newComment);

            var response = new ChronicleResponse<Comment>();
            response.ForAdd(serviceResult);
            return response;
        }

        [HttpGet]
        [Route("book/{bookId}")]
        public ChronicleResponse<BookCommentsDetailsDto> GetAllForBook(int bookId)
        {
            var serviceResult = _commentService.GetAllCommentsForBook(bookId);

            var response = new ChronicleResponse<BookCommentsDetailsDto>();
            response.ForLookup(serviceResult);
            return response;
        }
    }
}
