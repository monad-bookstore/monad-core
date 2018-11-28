using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class CaseAttachment
    {
        public int Id { get; set; }
        public int CaseMessageId { get; set; }
        public string AttachmentUrl { get; set; }

        public CaseMessage CaseMessage { get; set; }
    }
}
