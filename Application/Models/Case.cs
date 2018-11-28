using System;
using System.Collections.Generic;

namespace Application.Models
{
    public partial class Case
    {
        public Case()
        {
            CaseMessages = new HashSet<CaseMessage>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SupportId { get; set; }
        public byte Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Client Client { get; set; }
        public Client Support { get; set; }
        public ICollection<CaseMessage> CaseMessages { get; set; }
    }
}
