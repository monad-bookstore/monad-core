using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Order
    {
        public Order()
        {
            Ordered = new HashSet<Ordered>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int AddressId { get; set; }
        public byte Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Address Address { get; set; }
        public Client Client { get; set; }
        public ICollection<Ordered> Ordered { get; set; }
    }
}
