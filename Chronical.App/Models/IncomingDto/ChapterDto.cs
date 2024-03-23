using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class ChapterDto
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public int ChapterNumber { get; set; }
        [Required]
        public BookDto? Book { get; set; }
    }
}
