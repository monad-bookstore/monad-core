using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class BookCreationData
    {
        public string Title { get; set; }
        public List<int> Authors { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
    }
}
