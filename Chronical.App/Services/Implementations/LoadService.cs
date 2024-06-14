using Chronical.App.Models.IncomingDto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class LoadService : ILoadService
    {
        private IAuthorRepository _authorRepository { get; set; }

        public LoadService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task AddAuthor(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }

        public Task AddBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Task AddChapter(ChapterDto chapterDto)
        {
            throw new NotImplementedException();
        }

        public Task AddCharacter(CharacterDto characterDto)
        {
            throw new NotImplementedException();
        }

        public Task AddComment(CommentDto commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
