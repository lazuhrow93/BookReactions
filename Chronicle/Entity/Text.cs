using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Text : IEntity
    {
        public int Id { get; set; }
        public string? TextLiteral { get; set; }
        public int LanguageTypeId { get; set; }
    }
}
