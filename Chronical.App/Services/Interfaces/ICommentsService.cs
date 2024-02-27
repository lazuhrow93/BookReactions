using Chronicle.Domain.Entity;
using System;
using Chronicle.Domain.Entity.Interfaces;
using Chronical.Domaion.FrontEnd;

namespace Chronical.App.Services.Interfaces
{
    public interface ICommentsService
    {
        public ChapterCommentsDto UnderChapter(int chapterId); 
    }
}
