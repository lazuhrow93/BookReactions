using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Repositories
{
    public enum State
    {
        None,
        NotAdded,
        Added,
        NotFound,
        Found,
        AlreadyExists
    }

    public class RepositoryResult<T>
    {
        public List<string> Errors { get; set; }
        private State State { get; set; }
        public T? Entity { get; set; }

        public bool EntityAdded => (State == State.Added);
        public bool EntityFound => (State == State.Found);

        public RepositoryResult()
        {
            Errors = new();
            State = State.None;
        }

        public RepositoryResult<T> SetState(State state)
        {
            State = state; 
            return this;
        }

        public RepositoryResult<T> AddError(string error)
        {
            if(this.Errors == null) this.Errors = new List<string>();
            this.Errors.Add(error);

            return this;
        }
        
        public RepositoryResult<T> AddError(List<string> error)
        {
            if (this.Errors == null) this.Errors = new List<string>();
            this.Errors.AddRange(error);

            return this;
        }
    }
}
