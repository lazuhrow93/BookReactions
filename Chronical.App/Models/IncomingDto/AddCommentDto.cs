using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class AddCommentDto
    {
        [Required]
        public string? Value { get; set; }
        [Required]
        public int CharacterId { get; set; }
        public int ChapterNumber { get; set; }
    }
}
