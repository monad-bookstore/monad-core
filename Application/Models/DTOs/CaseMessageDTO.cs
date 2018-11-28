using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class CaseMessageDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Contents { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
