using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}
