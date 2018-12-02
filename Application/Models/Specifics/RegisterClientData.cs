using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Specifics
{
    public class RegisterClientData
    {
        [Required(ErrorMessage = "Privalote įvesti vartotojo vardą.")]
        [MinLength(6, ErrorMessage = "Vartotojo vardas turi susidaryti bent iš 6 simbolių.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Privalote įvesti slaptažodį.")]
        [MinLength(6, ErrorMessage = "Slaptažodis turi susidaryti bent iš 6 simbolių.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Privalote įvesti el. pašto adresą.")]
        [EmailAddress(ErrorMessage = "Neteisingas el. pašto adreso formatas.")]
        public string Mail { get; set; }
    }
}
