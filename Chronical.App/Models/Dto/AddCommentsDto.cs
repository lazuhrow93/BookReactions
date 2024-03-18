using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Models.Dto
{
    public class AddCommentsDto
    {
        [Required]
        public string? SubText { get; set; }
        [Required]
        public string? Comment { get; set; }
    }
}
