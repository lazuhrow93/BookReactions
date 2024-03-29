using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Services.Extensions;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chronical.App.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private IMapper _mapper;

        public AuthorService(IAuthorRepository repository,
            IMapper mapper)
        {
            _authorRepository = repository;
            _mapper = mapper;
        }

        public RepositoryResult<Author> AddAuthor(AuthorDto dto)
        {
            var existingAuthor = _authorRepository.GetByFullName(dto.FirstName!, dto.MiddleName, dto.LastName!);
            var result = new RepositoryResult<Author>();
            result.SetState(State.NotAdded);

            if(existingAuthor != null)
            {
                result
                    .SetState(State.AlreadyExists)
                    .AddError("This author already exists");
                return result;
            }

            var newAuthorEntity = _mapper.Map<Author>(dto);
            var entityTracker = _authorRepository.Add(newAuthorEntity);
            _authorRepository.SaveChanges();
            result.SetState(State.Added);
            result.Entity = entityTracker.Entity;
            return result;
        }

        public RepositoryResult<Author> GetAuthor(AuthorDto dto)
        {
            var repoResult = new RepositoryResult<Author>();
            repoResult.SetState(State.NotFound);

            var result = _authorRepository.GetByFullName(dto.FirstName!, dto.MiddleName, dto.LastName!);

            repoResult.Entity = result;
            if (result == null)
                repoResult.AddError("Unable to find author by these creds");
            else
                repoResult.SetState(State.Found);

            return repoResult;
        }
    }
}
