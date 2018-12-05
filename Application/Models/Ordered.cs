using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Ordered
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
