using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
