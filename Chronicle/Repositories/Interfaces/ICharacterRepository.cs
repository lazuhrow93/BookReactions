using Chronicle.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface ICharacterRepository : IRepository<Character>
    {
        public IEnumerable<Character> GetByBook(int bookId);
        public Character? FindByBook(int bookId, string name);
    }
}
