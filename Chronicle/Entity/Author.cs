namespace Chronicle.Domain.Entity
{
    public class Author : Entity<Author>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
    }
}
