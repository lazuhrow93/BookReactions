using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        public TEntity? Get(int id);
        public TEntity Add(TEntity entity);
        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        public TEntity Update(TEntity entity);
        public void Delete(TEntity entities);
        public void Delete(IEnumerable<TEntity> entities);
        public void SaveChanges();
    }
}
