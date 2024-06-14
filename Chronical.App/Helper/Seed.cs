using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Helper
{
    public class Seed
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IChapterService _chapterService;
        private readonly ICharacterService _characterService;
        private readonly ICommentService _commentService;
        public Seed(
            IAuthorService authorService,
            IBookService bookSerivce,
            IChapterService chapterService,
            ICharacterService characterService,
            ICommentService commentService)
        {
            _authorService = authorService;
            _bookService = bookSerivce;
            _chapterService = chapterService;
            _characterService = characterService;
            _commentService = commentService;
        }

        public Seed SeedBasicData()
        {
            var authorDto = new AuthorDto()
            {
                FirstName = "Lazaro",
                LastName = "Hernandez",
            };
            var author = _authorService.AddAuthor(authorDto).Entity;

            var bookDto = new BookDto()
            {
                Title = "Wheel Of Time",
                AuthorId = author!.Id
            };

            var book = _bookService.AddBook(bookDto).Entity;

            var chapterDtos = new List<ChapterDto>()
            {
                new ChapterDto() { BookId = book!.Id, Title = "The Beginning and the End", ChapterNumber = 1 },
                new ChapterDto() { BookId = book.Id, Title = "Enter The Light", ChapterNumber = 2 },
                new ChapterDto() { BookId = book.Id, Title = "Gentle vs Stilling", ChapterNumber = 3 },
                new ChapterDto() { BookId = book.Id, Title = "The Dragon", ChapterNumber = 4 },
                new ChapterDto() { BookId = book.Id, Title = "The Wolf", ChapterNumber = 5 },
            };

            var chapters = _chapterService.AddChapter(chapterDtos).Entity;

            var characterDtos = new List<CharacterDto>()
            {
                new CharacterDto () {Name = "Rand Al'Thor", BookId = book.Id },
                new CharacterDto () {Name = "Perrin Aybara", BookId = book.Id },
                new CharacterDto () {Name = "Matrim Cauthon", BookId = book.Id },
                new CharacterDto () {Name = "Egwene Al'Vere", BookId = book.Id }
            };

            var characters = _characterService.AddCharacter(characterDtos).Entity!.ToList();

            var commentDtos = new List<CommentDto>()
            {
                new CommentDto(){BookId = book.Id, ChapterNumber = 1, CharacterId = characters[0].Id, Value = "RAND Comment 1" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 1, CharacterId = characters[0].Id, Value = "RAND Comment 2" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 1, CharacterId = characters[0].Id, Value = "RAND Comment 3" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 1, CharacterId = characters[3].Id, Value = "EGWENE Comment 1" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 2, CharacterId = characters[1].Id, Value = "PERRIN Comment 1" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 2, CharacterId = characters[1].Id, Value = "PERRIN Comment 2" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 3, CharacterId = characters[0].Id, Value = "RAND Comment 4" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 3, CharacterId = characters[0].Id, Value = "RAND Comment 5" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 4, CharacterId = characters[0].Id, Value = "RAND Comment 6" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[3].Id, Value = "EGWENE Comment 2" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[3].Id, Value = "EGWENE Comment 3" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[3].Id, Value = "EGWENE Comment 4" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[3].Id, Value = "EGWENE Comment 5" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[0].Id, Value = "RAND Comment 1" },
                new CommentDto(){BookId = book.Id, ChapterNumber = 5, CharacterId = characters[1].Id, Value = "PERRIN Comment 3" },
            };

            var comments = _commentService.AddCommentForCharacter(commentDtos).Entity!;

            return this;
        }
    }
}
