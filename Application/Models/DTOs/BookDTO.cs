using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class BookDTO
    {
        public BookDTO()
        {
            Authors = new HashSet<int>();
        }

        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public ICollection<int> Authors { get; set; }
    }
}
