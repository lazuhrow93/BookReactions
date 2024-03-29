using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class CharacterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
