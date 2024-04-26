namespace Chronical.App.Models.OutgoingDto
{
    public class BookCommentsDetailsDto
    {
        public string? Title { get; set; }
        public int BookId { get; set; }
        public List<CharacterCommentsDto> Comments { get; set; } = new List<CharacterCommentsDto>();
    }
}
