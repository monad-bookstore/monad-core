using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Models
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            Cases = new HashSet<Case>();
            CasesSupports = new HashSet<Case>();
            Orders = new HashSet<Order>();
            Profiles = new HashSet<Profile>();
            PhoneNumbers = new HashSet<PhoneNumber>();
        }

        [BindNever]
        public int Id { get; set; }

        [BindNever]
        public byte AccessFlag { get; set; }

        [BindNever]
        public string AuthorizationKey { get; set; }

        [BindNever]
        public string Username { get; set; }

        [StringLength(254)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [BindNever]
        public DateTime? UpdatedAt { get; set; }

        [BindNever]
        public DateTime? CreatedAt { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<Case> Cases { get; set; }
        public ICollection<Case> CasesSupports { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
