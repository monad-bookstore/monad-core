using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class AssignCaseSupport
    {
        [Required]
        public int CaseId { get; set; }
        [Required]
        public int SupportId { get; set; }
    }
}
