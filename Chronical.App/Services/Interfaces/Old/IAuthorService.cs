using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Services.Interfaces.Old
{
    public interface IAuthorService
    {
        RepositoryResult<Author> AddAuthor(AuthorDto newAuthor);
        RepositoryResult<Author> GetAuthor(AuthorDto dto);
    }
}
