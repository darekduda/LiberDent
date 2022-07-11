using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Account
{
    public class AdresUzytkownika
    {
        [Key]
        public int IdAdresu { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę miejscowości")]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }

        [Required(ErrorMessage = "Wpisz numer domu")]
        [StringLength(15, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Numer domu")]
        public string NumerDomu { get; set; }

        [StringLength(15, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Numer lokalu")]
        public string NumerLokalu { get; set; }

        [Required(ErrorMessage = "Wpisz ulicę")]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Wpisz kod pocztowy")]
        [StringLength(7, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Kod pocztowy")]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę poczty")]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Poczta")]
        public string Poczta { get; set; }

        public string IdUzytkownika { get; set; }
        public virtual ApplicationUser Uzytkownik { get; set; }
    }
    }

