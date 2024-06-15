﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Domain.Entity
{
    public class Chapter : Entity
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int Number { get; set; }
    }
}
