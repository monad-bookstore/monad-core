using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.DTOs;

namespace Application.Models.Specifics
{
    public class OrderExpanded
    {
        public int Id { get; set; }
        public ClientExpanded Client { get; set; }
        public AddressDTO Address { get; set; }
        public List<BookDTO> Products { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
