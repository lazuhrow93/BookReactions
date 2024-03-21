using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private ChronicleDBContext _context { get; set; }

        public IQueryable<Book> Query 
        {
            get { return _context.Set<Book>().AsQueryable<Book>(); } 
        }

        public BookRepository(ChronicleDBContext context)
        {
            _context = context;
        }

        public Book Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Add(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Book? Get(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Book Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
