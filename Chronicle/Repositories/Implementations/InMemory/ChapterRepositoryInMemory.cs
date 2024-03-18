using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Chronicle.Domain.Repositories.Implementations.InMemory
{
    public class ChapterRepositoryInMemory : IChapterRepository
    {
        public object _locker = new();
        private int _identityId = 1;
        private Dictionary<int, Chapter> _softCopy = new Dictionary<int, Chapter>();
        private Dictionary<int, Chapter> _hardCopy = new Dictionary<int, Chapter>();

        public IQueryable<Chapter> chapters
        {
            get { return _softCopy.Values.AsQueryable(); }
        }

        public Chapter Add(Chapter entity)
        {
            AssignId(entity);
            _softCopy.Add(entity.Id, entity);
            return entity;
        }

        public IEnumerable<Chapter> Add(IEnumerable<Chapter> entities)
        {
            foreach (var chapter in entities)
            {
                AssignId(chapter);
                _softCopy.Add(chapter.Id, chapter);
            }
            return entities;
        }

        public void Delete(Chapter entities)
        {
            _softCopy.Remove(entities.Id);
        }

        public void Delete(IEnumerable<Chapter> entities)
        {
            foreach (var chapter in entities)
            {
                _softCopy.Remove(chapter.Id);
            }
        }

        public Chapter? Get(int id)
        {
            _softCopy.TryGetValue(id, out Chapter? value);
            return value;
        }

        public void SaveChanges()
        {
            _hardCopy = _softCopy;
        }

        public Chapter Update(Chapter entity)
        {
            _softCopy.TryGetValue(entity.Id, out Chapter? value);
            if (value is null) throw new Exception($"This chapter doesnt exist");

            _softCopy[entity.Id] = entity;
            return _softCopy[entity.Id];
        }

        private void AssignId(Chapter chapter)
        {
            lock (_locker)
            {
                chapter.Id = _identityId++;
            }
        }
    }
}
