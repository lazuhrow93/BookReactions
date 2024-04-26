using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Helper
{
    public class Seed
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IChapterRepository _chapterRepo;
        private readonly ICharacterRepository _characterRepo;
        private readonly ICommentRepository _commentRepo;
        public Seed(
            IAuthorRepository authorRepo,
            IBookRepository bookRepo,
            IChapterRepository chapterRepo,
            ICharacterRepository characterRepo,
            ICommentRepository commentRepo)
        {
            _authorRepo = authorRepo;
            _bookRepo = bookRepo;
            _chapterRepo = chapterRepo;
            _characterRepo = characterRepo;
            _commentRepo = commentRepo;
        }

        public Seed SeedBasicData()
        {
            var author = new Author()
            {
                FirstName = "Lazaro",
                LastName = "Hernandez",
                Id = 1
            };

            var book = new Book()
            {
                Id = 1,
                Title = "Wheel Of Time",
                AuthorId = author.Id
            };

            var chapters = new List<Chapter>()
            {
                new Chapter() { Id = 1, BookId = book.Id, Title = "The Beginning and the End", Number = 1 },
                new Chapter() { Id = 2, BookId = book.Id, Title = "Enter The Light", Number = 2 },
                new Chapter() { Id = 3, BookId = book.Id, Title = "Gentle vs Stilling", Number = 3 },
                new Chapter() { Id = 4, BookId = book.Id, Title = "The Dragon", Number = 4 },
                new Chapter() { Id = 5, BookId = book.Id, Title = "The Wolf", Number = 5 },
            };

            var characters = new List<Character>()
            {
                new Character () {Id = 1, FullName = "Rand Al'Thor", BookId = book.Id },
                new Character () {Id = 2, FullName = "Perrin Aybara", BookId = book.Id },
                new Character () {Id = 3, FullName = "Matrim Cauthon", BookId = book.Id },
                new Character () {Id = 4, FullName = "Egwene Al'Vere", BookId = book.Id }
            };

            var comments = new List<Comment>()
            {
                new Comment(){Id = 1, BookId = book.Id, ChapterNumber = 1, CharacterId = 1, Value = "RAND Comment 1" },
                new Comment(){Id = 2, BookId = book.Id, ChapterNumber = 1, CharacterId = 1, Value = "RAND Comment 2" },
                new Comment(){Id = 3, BookId = book.Id, ChapterNumber = 1, CharacterId = 1, Value = "RAND Comment 3" },
                new Comment(){Id = 4, BookId = book.Id, ChapterNumber = 1, CharacterId = 4, Value = "EGWENE Comment 1" },
                new Comment(){Id = 5, BookId = book.Id, ChapterNumber = 2, CharacterId = 2, Value = "PERRIN Comment 1" },
                new Comment(){Id = 6, BookId = book.Id, ChapterNumber = 2, CharacterId = 2, Value = "PERRIN Comment 2" },
                new Comment(){Id = 7, BookId = book.Id, ChapterNumber = 3, CharacterId = 1, Value = "RAND Comment 4" },
                new Comment(){Id = 8, BookId = book.Id, ChapterNumber = 3, CharacterId = 1, Value = "RAND Comment 5" },
                new Comment(){Id = 9, BookId = book.Id, ChapterNumber = 4, CharacterId = 1, Value = "RAND Comment 6" },
                new Comment(){Id = 10, BookId = book.Id, ChapterNumber = 5, CharacterId = 4, Value = "EGWENE Comment 2" },
                new Comment(){Id = 11, BookId = book.Id, ChapterNumber = 5, CharacterId = 4, Value = "EGWENE Comment 3" },
                new Comment(){Id = 12, BookId = book.Id, ChapterNumber = 5, CharacterId = 4, Value = "EGWENE Comment 4" },
                new Comment(){Id = 13, BookId = book.Id, ChapterNumber = 5, CharacterId = 4, Value = "EGWENE Comment 5" },
                new Comment(){Id = 14, BookId = book.Id, ChapterNumber = 5, CharacterId = 1, Value = "RAND Comment 1" },
                new Comment(){Id = 15, BookId = book.Id, ChapterNumber = 5, CharacterId = 2, Value = "PERRIN Comment 3" },
            };

            _authorRepo.Add(author);
            _bookRepo.Add(book);
            _chapterRepo.Add(chapters);
            _characterRepo.Add(characters);
            _commentRepo.Add(comments);

            _authorRepo.SaveChanges();
            _bookRepo.SaveChanges();
            _chapterRepo.SaveChanges();
            _characterRepo.SaveChanges();
            _commentRepo.SaveChanges();

            return this;
        }
    }
}
