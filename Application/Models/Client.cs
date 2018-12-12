using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            CaseClients = new HashSet<Case>();
            CaseSupports = new HashSet<Case>();
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            PhoneNumbers = new HashSet<PhoneNumber>();
            Profiles = new HashSet<Profile>();
            Ratings = new HashSet<Rating>();
            CaseMessageCollection = new HashSet<CaseMessage>();
        }

        public int Id { get; set; }
        public byte AccessFlag { get; set; }
        public string AuthorizationKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Case> CaseClients { get; set; }
        public ICollection<Case> CaseSupports { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public IEnumerable<CaseMessage> CaseMessageCollection { get; set; }
    }
}
