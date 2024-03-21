using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.Dto
{
    public class BookDto
    {
        [Required]
        public AuthorDto? Author { get; set; }
        [Required]
        public string? Title { get; set; }
    }
}
