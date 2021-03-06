﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class RatingData
    {
        [Range(1, int.MaxValue)]
        public int BookId { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
}
