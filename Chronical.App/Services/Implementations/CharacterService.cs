using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository repo,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _characterRepository = repo;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public RepositoryResult<Character> AddCharacter(CharacterDto dto)
        {
            var repoResult = new RepositoryResult<Character>();
            repoResult.SetState(State.NotAdded);

            var bookDoesNotExists = (_bookRepository.Get(dto.BookId) == null);
            if(bookDoesNotExists)
            {
                repoResult.AddError(string.Format("Unable to find the book with id {bookId}", dto.BookId));
                return repoResult;
            }

            var character = _mapper.Map<Character>(dto);
            var result = _characterRepository.Add(character);
            if (result.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                repoResult.SetState(State.Added);
                repoResult.Entity = result.Entity;
            }
            else
                repoResult.AddError("Unable to add the Character for unknown reason");

            _characterRepository.SaveChanges();
            return repoResult;
        }

        public RepositoryResult<IEnumerable<Character>> AddCharacter(IEnumerable<CharacterDto> characters)
        {
            var repoResult = new RepositoryResult<IEnumerable<Character>>();
            repoResult.SetState(State.NotAdded);

            var character = _mapper.Map<List<Character>>(characters);
            var result = _characterRepository.Add(character);
            if (result.All(e=>e.State == Microsoft.EntityFrameworkCore.EntityState.Added))
            {
                repoResult.SetState(State.Added);
                repoResult.Entity = result.Select(e=>e.Entity).AsEnumerable();
            }
            else
                repoResult.AddError("Unable to add the Character for unknown reason");

            _characterRepository.SaveChanges();
            return repoResult;
        }

        public RepositoryResult<List<Character>> GetAllCharactersByBook(int bookId)
        {
            var repoResult = new RepositoryResult<List<Character>>();
            repoResult.SetState(State.NotFound);

            var book = _bookRepository.Get(bookId);
            if(book is null)
            {
                repoResult.AddError(string.Format("Unable to find that book [{0}]", bookId));
            }

            var allCharacters = _characterRepository.GetByBook(bookId);
            if (allCharacters.Count() > 0)
                repoResult.SetState(State.Found);

            repoResult.Entity = allCharacters.ToList();
            return repoResult;

        }
    }
}
