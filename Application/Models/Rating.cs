using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int BookId { get; set; }
        public decimal Rating1 { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}
