using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Nicename { get; set; }
        public string Iso3 { get; set; }
        public short? Numcode { get; set; }
        public int Phonecode { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
