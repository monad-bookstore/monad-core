using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PhoneId { get; set; }
        public int CountryId { get; set; }
        public string Label { get; set; }
        public string AddressText { get; set; }
        public string City { get; set; }

        public Client Client { get; set; }
        public Country Country { get; set; }
        public PhoneNumber Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
