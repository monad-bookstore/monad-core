using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.DTOs;
using Application.Models.Specifics.Validators;

namespace Application.Models.Specifics
{
    public class CaseExpanded
    {
        public int Id { get; set; }
        public ClientExpanded Client { get; set; }
        public ClientExpanded Support { get; set; }
        [Required]
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte Status { get; set; }

        [EnsureOneElement]
        public ICollection<CaseMessageData> Messages;
        public ICollection<CaseAttachmentDTO> Attachments;
    }
}
