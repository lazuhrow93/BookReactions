using Bogus;
using Chronicle.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Tests.Utility.Faker
{
    public class EntityFaker<TEntity> : Faker<TEntity>
        where TEntity : Entity<TEntity>
    {
        public EntityFaker()
        {
            RuleFor(t => t.Id, f => f.Random.Int(1));
        }
    }
}
