using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories.Implementations
{
    public class AuthorRepository : EntityRepository<Author>
    {
        public AuthorRepository(ChronicleDbContext dBContext) : base(dBContext)
        {

        }
    }
}
