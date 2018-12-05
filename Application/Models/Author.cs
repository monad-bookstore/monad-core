using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
