using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class CommentDto
    {
        [Required]
        public string? SubText { get; set; }
        [Required]
        public string? Comment { get; set; }
        public ChapterDto Chapter { get; set; }
    }
}
