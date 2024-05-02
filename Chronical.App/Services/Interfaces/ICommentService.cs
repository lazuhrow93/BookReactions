using Chronical.App.Controllers;
using Chronical.App.Models;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentService
    {
        public RepositoryResult<List<Comment>> GetAllCharacterComments(int characterId);
        public RepositoryResult<Comment> AddCommentForCharacter(CommentDto dto);
        public RepositoryResult<IEnumerable<Comment>> AddCommentForCharacter(IEnumerable<CommentDto> dto);
        public RepositoryResult<BookCommentsDetailsDto> GetAllCommentsForBook(int bookId);
    }
}
