using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class BookDto
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string? Title { get; set; }
    }
}
