namespace Chronicle.Domain.Entity
{
    public class Author : IEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public int Id { get; set; }
    }
}
