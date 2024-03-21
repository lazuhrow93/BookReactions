using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories
{
    public enum State
    {
        NotAdded,
        Added,
    }

    public class ActionResult
    {
        public List<string>? Errors { get; set; }
        public State State { get; set; }
    }
}
