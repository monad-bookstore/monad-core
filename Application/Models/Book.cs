using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            Comments = new HashSet<Comment>();
            Ordered = new HashSet<Ordered>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Category Category { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Ordered> Ordered { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
