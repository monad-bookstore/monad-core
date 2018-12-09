using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class CategoryCreationData
    {
        [Required]
        public string Label { get; set; }
        public int ParentId { get; set; }

        CategoryCreationData()
        {
            ParentId = 0;
        }
    }
}
