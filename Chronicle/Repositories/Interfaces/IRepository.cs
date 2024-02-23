using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public T Get(int id);
        public IQueryable<T> FetchAll();
    }
}
