using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class CenyUslug
    {
        [Key]
        public int IdCenyUslug { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę")]
        [StringLength(100, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Nazwa")]
        public string NazwaUslugi { get; set; }

        [Required(ErrorMessage = "Wpisz cenę")]
        [Display(Name = "Cena")]
        public decimal CenaUslugi { get; set; }

    }
}
