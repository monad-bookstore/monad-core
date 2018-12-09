using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class CommentCreationData
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int BookId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
