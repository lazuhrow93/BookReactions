using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime SyncTimestamp { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
