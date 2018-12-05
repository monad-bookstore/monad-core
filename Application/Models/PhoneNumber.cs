using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class PhoneNumber
    {
        public PhoneNumber()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }

        public Client Client { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
