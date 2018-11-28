using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Models.DTOs
{
    public class ClientDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION
        [Required]
        public int Id { get; set; }
        public byte AccessFlag { get; set; }
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Neteisingas el. pašto adreso formatas.")]
        public string Email { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
