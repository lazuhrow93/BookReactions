using Chronicle.Domain.Entity;
using System;
using Chronicle.Domain.Entity.Interfaces;

namespace Chronical.App.Services.Interfaces
{
    public interface IViewChapterCommentsService
    {
        public Comment[] GetCommentsForBook(int bookId, int chapterId); 
    }
}
