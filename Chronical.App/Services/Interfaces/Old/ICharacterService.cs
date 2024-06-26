﻿using Chronical.App.Models.IncomingDto;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;

namespace Chronical.App.Services.Interfaces.Old
{
    public interface ICharacterService
    {
        public RepositoryResult<Character> AddCharacter(CharacterDto character);
        public RepositoryResult<IEnumerable<Character>> AddCharacter(IEnumerable<CharacterDto> characters);

        public RepositoryResult<List<Character>> GetAllCharactersByBook(int bookId);
    }
}
