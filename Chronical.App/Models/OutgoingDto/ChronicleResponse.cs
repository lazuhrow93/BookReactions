using Chronicle.Domain.Repositories;

namespace Chronical.App.Models.OutgoingDto
{
    public class ChronicleResponse<T>
    {
        public bool Success { get; set; }
        public string[]? Error { get; set; }
        public T? Data { get; set; }

        public ChronicleResponse<T> ForAdd(RepositoryResult<T> result)
        {
            this.Data = result.Entity;
            this.Error = result.Errors.ToArray();
            this.Success = result.EntityAdded;
            return this;
        }

        public ChronicleResponse<T> ForLookup(RepositoryResult<T> result)
        {
            this.Data = result.Entity;
            this.Error = result.Errors.ToArray();
            this.Success = result.EntityFound;
            return this;
        }
    }
}
