using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class CaseMessage
    {
        public CaseMessage()
        {
            CaseAttachments = new HashSet<CaseAttachment>();
        }

        public int Id { get; set; }
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public string Contents { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Client Client { get; set; }
        public Case Case { get; set; }
        public ICollection<CaseAttachment> CaseAttachments { get; set; }
    }
}
