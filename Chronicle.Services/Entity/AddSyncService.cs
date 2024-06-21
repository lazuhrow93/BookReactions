using AutoMapper;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Services.Dto;
using Chronicle.Services.Specifications;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chronicle.Services.Entity
{
    public class AddSyncService : IAddSyncService
    {
        private readonly IEntitySyncService _syncService;
        private readonly IMapper _mapper;

        public AddSyncService(IEntitySyncService syncService,
            IMapper mapper)
        {
            _syncService = syncService;
            _mapper = mapper;
        }

        public async Task AddAuthor(AuthorDto author)
        {
            var valueIfExist = await _syncService.Get(AuthorSpecification.ByAuthorNames(author.FirstName, author.MiddleName, author.LastName));
            if (valueIfExist?.First() != null)
            {
                //what do? should ignore since it exists already
                return;
            }
            else
            {
                var newEntity = _mapper.Map<Author>(author);
                await _syncService.Add(newEntity);
            }
        }

        public async Task AddBook(BookDto book)
        {
            var entityExist = await _syncService.Get(BookSpecification.ByAuthorIdAndTitle(book.AuthorId, book.Title));
            if(entityExist?.First() != null)
            {
                //what do? should ignore since it already exists
                return;
            }
            else
            {
                var newEntity = _mapper.Map<Book>(book);
                await _syncService.Add(newEntity);
            }
        }
    }

    public interface IAddSyncService
    {
        Task AddAuthor(AuthorDto author);
        Task AddBook(BookDto book);
    }
}
