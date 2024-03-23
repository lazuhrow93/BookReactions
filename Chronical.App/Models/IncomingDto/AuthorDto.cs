using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.IncomingDto
{
    public class AuthorDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
