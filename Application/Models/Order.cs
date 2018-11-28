﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public byte Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Address Address { get; set; }
        [IgnoreDataMember]
        public Client Client { get; set; }
    }
}