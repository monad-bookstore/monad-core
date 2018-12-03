using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.DTOs;

namespace Application.Models.Specifics
{
    /**
     * Book related data specially designed for store.
     * Comments, ratings in the future should be added here.
     */
    public class ProductExpanded
    {
        public ProductExpanded()
        {
            Authors = new HashSet<AuthorDTO>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
    }
}
