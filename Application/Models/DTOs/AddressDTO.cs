using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Application.Models.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required]
        public int PhoneId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string AddressText { get; set; }
        [Required]
        public string City { get; set; }
    }
}
