using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public interface IEntity
    {
        int Id { get; }
        DateTime SyncTimestamp { get; }
        DateTime CreatedDate { get; }
    }
}
