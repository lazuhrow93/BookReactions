using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.Dto
{
    public class AddBookDto
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
    }
}
