using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class CountryDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Nicename { get; set; }
        public string Iso3 { get; set; }
        public short? Numcode { get; set; }
        public int Phonecode { get; set; }
    }
}
