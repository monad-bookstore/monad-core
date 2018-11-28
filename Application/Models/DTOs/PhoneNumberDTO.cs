using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class PhoneNumberDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
    }
}
