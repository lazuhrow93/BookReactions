using System.ComponentModel.DataAnnotations;
using Chronical.App.Models.IncomingDto;

namespace Chronical.App.Models.OutgoingDto
{
    public class CommentDetailsDto
    {
        public int ChapterNumber { get; set; }
        public string? Text { get; set; }
    }
}
