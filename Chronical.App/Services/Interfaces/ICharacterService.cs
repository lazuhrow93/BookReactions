using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces
{
    public interface ICharacterService
    {
        public RepositoryResult<Character> AddCharacter(CharacterDto character);

        public RepositoryResult<List<Character>> GetCharacters(CharacterDto dto);

        public RepositoryResult<List<Character>> GetAllCharactersByBook(int bookId);
    }
}
