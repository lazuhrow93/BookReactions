using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Interfaces
{
    public interface ILoadService
    {
        Task AddAuthor(AuthorDto authorDto);
        Task AddBook(BookDto bookDto);
        Task AddChapter(ChapterDto chapterDto);
        Task AddCharacter(CharacterDto characterDto);
        Task AddComment(CommentDto commentDto);
    }
}
