using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Chronical.App.Services.Extensions
{
    public static class ChapterRepositoryExtensions
    {
        public static Chapter? GetByBookAndNumber(this IChapterRepository repo, int bookId, int chapternumber)
        {
            var chaptersInBook = repo.Query.Where(c => c.BookId == bookId);
            if (chaptersInBook?.Any() != true) return null;

            return chaptersInBook.Where(c=>c.Number == chapternumber).FirstOrDefault();
        }
    }
}
