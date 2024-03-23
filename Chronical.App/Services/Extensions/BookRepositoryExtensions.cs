using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Implementations;
using Chronicle.Domain.Repositories.Interfaces;
using SpicyWing.Extensions;

namespace Chronical.App.Services.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static List<Book> FindBookByAuthorAndTitle(this IBookRepository repo, int authorId, string title)
        {
            var booksByAuthor = repo.Query.Where(b => b.AuthorId == authorId);
            if (booksByAuthor?.Any() != true) new List<Book>();
            return booksByAuthor!.Where(b => b.Title != null && b.Title.Like(title)).ToList();
        }
    }
}
