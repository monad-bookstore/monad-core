﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PhoneId { get; set; }
        public int CountryId { get; set; }
        public string Label { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        [IgnoreDataMember]
        public Client Client { get; set; }
        public PhoneNumber Phone { get; set; }
    }
}