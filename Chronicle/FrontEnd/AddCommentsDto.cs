using System.ComponentModel.DataAnnotations;

namespace Chronical.App.Controllers
{
    public class AddCommentsDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public string SubText { get; set; }
        [Required]
        public int ChapterId { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
