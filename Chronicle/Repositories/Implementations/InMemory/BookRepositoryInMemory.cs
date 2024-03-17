using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations.InMemory
{
    internal class BookRepositoryInMemory : IBookRepository
    {
        private object _locker = new object();
        private int _identityId = 1;

        private Dictionary<int, Book> _softCopy = new();
        private Dictionary<int, Book> _hardCopy = new();

        public IQueryable<Book> books
        {
            get { return _softCopy.Values.AsQueryable(); }
        }

        public Book Add(Book book)
        {
            book.Id = _identityId++;
            _softCopy[book.Id] = book;
            return _softCopy[book.Id];
        }

        public IEnumerable<Book> Add(IEnumerable<Book> books)
        {
            var startId = _identityId;
            foreach(var book in books)
            {
                book.Id = _identityId++;
                _softCopy[book.Id] = book;
            }
            var finalId = _identityId;
            return _softCopy.Where(d => d.Key > startId && d.Key < finalId).Select(d => d.Value);
        }

        public void Delete(Book book)
        {
            _softCopy.Remove(book.Id);
        }

        public void Delete(IEnumerable<Book> books)
        {
            foreach(var book in books)
            {
                _softCopy.Remove(book.Id);
            }
        }

        public Book? Get(int id)
        {
            _softCopy.TryGetValue(id, out var book);
            return book;
        }

        public void SaveChanges()
        {
            _hardCopy = _softCopy;
        }

        public Book Update(Book newbook)
        {
            _softCopy[newbook.Id] = newbook;
            return _softCopy[newbook.Id];
        }
    }
}
