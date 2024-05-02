using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class CommentDto
    {
        [Required]
        public string? Value { get; set; }
        [Required]
        public int CharacterId { get; set; }
        public int ChapterNumber { get; set; }
        public int BookId { get; set; }
    }
}
