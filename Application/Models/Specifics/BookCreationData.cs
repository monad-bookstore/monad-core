using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Specifics.Validators;

namespace Application.Models.Specifics
{
    public class BookCreationData
    {
        [Required(ErrorMessage = "Knygos pavadinimas privalo būti įvestas.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Reikalingas bent vienas knygos autorius.")]
        [EnsureOneElement(ErrorMessage = "Reikalingas bent vienas knygos autorius.")]
        public List<int> Authors { get; set; }
        [Required(ErrorMessage = "Kategorija privalo būti parinkta.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Viršelio adresas privalo būti nurodytas.")]
        public string Cover { get; set; }
        [Required(ErrorMessage = "Knygos kaina privalo būti nurodyta.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Knygos puslapių skaičius privalo būti nurodytas")]
        public int Pages { get; set; }
        [Required(ErrorMessage = "Knygos aprašymas privalo būti įvestas.")]
        public string Description { get; set; }
    }
}
