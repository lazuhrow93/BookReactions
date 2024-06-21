using Chronicle.Services.Dto;

namespace Chronicle.Services.Entity
{
    public interface IAuthorSyncService
    {
        Task AddAuthor(AuthorDto author);
    }
}
