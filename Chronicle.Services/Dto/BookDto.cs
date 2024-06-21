namespace Chronicle.Services.Dto
{
    public class BookDto : EntityDto
    {
        public int AuthorId { get; set; }
        public string? Title { get; set; }
    }
}
