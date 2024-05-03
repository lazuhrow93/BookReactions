namespace Chronical.App.Models.OutgoingDto
{
    public class BookCommentsDetailsDto
    {
        public string? BookTitle { get; set; }
        public int BookId { get; set; }
        public List<CharacterCommentsDto> CharacterComments { get; set; } = new List<CharacterCommentsDto>();
    }
}
