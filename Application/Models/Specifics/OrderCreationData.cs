using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Specifics.Validators;

namespace Application.Models.Specifics
{
    public class OrderCreationData
    {
        [Required(ErrorMessage = "Užsakyme privalo būti bent vienas produktas.")]
        [EnsureOneElement(ErrorMessage = "Užsakyme privalo būti bent vienas produktas.")]
        public List<int> Books { get; set; }

        [Required(ErrorMessage = "Privaloma nurodyti pristatymo adresą.", AllowEmptyStrings = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Privaloma nurodyti pristatymo adresą.")]
        public int AddressId { get; set; }
    }
}
