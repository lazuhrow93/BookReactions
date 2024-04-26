using System.ComponentModel.DataAnnotations;
using Chronical.App.Models.IncomingDto;

namespace Chronical.App.Models.OutgoingDto
{
    public class CommentDto
    {
        public int ChapterNumber { get; set; }
        public string? Text { get; set; }
    }
}
