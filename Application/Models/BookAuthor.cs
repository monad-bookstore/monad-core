﻿using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
