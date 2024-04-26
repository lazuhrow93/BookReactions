using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using CommonLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class CharacterRepository : EntityRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ChronicleDbContext context) : base(context)
        {
            
        }

        public Character? FindByBook(int bookId, string name)
        {
            var charsInBook = Query.Where(c => c.BookId == bookId);
            return charsInBook.FirstOrDefault(c => c.FullName != null && c.FullName!.Like(name));

        }

        public IEnumerable<Character> GetByBook(int bookId)
        {
            var allChars = Query.ToList();
            return Query.Where(c => c.BookId == bookId).AsEnumerable();
        }
    }
}
