using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public int ClientId { get; set; }
        public int CountryId { get; set; }
        public string Label { get; set; }
        public string AddressText { get; set; }
        public string City { get; set; }

        public Client Client { get; set; }
        public PhoneNumber Phone { get; set; }
    }
}
