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
        [Required]
        public string Contents { get; set; }
        public ICollection<CaseAttachmentDTO> Attachments { get; set; }

        public static ICollection<CaseMessageData> Create(ICollection<CaseMessage> messages)
        {
            var result = new List<CaseMessageData>();
            foreach (var message in messages)
            {
                result.Add(new CaseMessageData()
                {
                    Contents = message.Contents,
                    Id = message.Id,
                    Attachments = message.CaseAttachments.Select(c => new CaseAttachmentDTO
                    {
                        AttachmentUrl = c.AttachmentUrl,
                        CaseMessageId = message.Id,
                        Id = c.Id
                    }).ToList()
                });
            }

            return result;
        }
    }
}
