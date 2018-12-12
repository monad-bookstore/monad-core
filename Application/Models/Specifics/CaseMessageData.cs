using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Models.DTOs;
using Application.Models.Specifics.Validators;

namespace Application.Models.Specifics
{
    public class CaseMessageData
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        [Required]
        public string Contents { get; set; }
        public ICollection<CaseAttachmentDTO> Attachments { get; set; }
    }
}
