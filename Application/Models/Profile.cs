using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Client Client { get; set; }
    }
}
