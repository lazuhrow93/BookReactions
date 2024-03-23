using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using CommonLibrary.Extensions;

namespace Chronicle.Domain.Repositories.Implementations.InMemory
{
    public class BookRepositoryInMemory : EntityRepository<Book>
    {
        private object _locker = new object();
        private int _identityId = 1;

        private Dictionary<int, Book> _softCopy = new();
        private Dictionary<int, Book> _hardCopy = new();

        public BookRepositoryInMemory(ChronicleDbContext context) : base(context)
        {
            
        }

        public IQueryable<Book> Query
        {
            get { return _softCopy.Values.AsQueryable(); }
        }

        public Book Add(Book book)
        {
            AssignId(book);
            _softCopy[book.Id] = book;
            return _softCopy[book.Id];
        }

        public IEnumerable<Book> Add(IEnumerable<Book> books)
        {
            var startId = _identityId;
            foreach(var book in books)
            {
                AssignId(book);
                _softCopy[book.Id] = book;
            }
            var finalId = _identityId;
            return _softCopy.Where(d => d.Key >= startId && d.Key < finalId).Select(d => d.Value);
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

        private void AssignId(Book book)
        {
            lock (_locker)
            {
                book.Id = _identityId++;
            }
        }
    }
}
