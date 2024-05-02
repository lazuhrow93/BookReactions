namespace Chronical.App.Models.OutgoingDto
{
    public class CharacterCommentsDto
    {
        public string? CharacterName { get; set; }
        public int CharacterId { get; set; }
        public List<CommentDetailsDto> Comments { get; set; } = new List<CommentDetailsDto>();
    }
}
