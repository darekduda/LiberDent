using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Account
{
    public class DaneUzytkownika
    {
        [Key]
        public int IdDaneUzytkownika { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wpisz swoje imię")]
        [StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wpisz swoje nazwisko")]
        [StringLength(70, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wprowadź swoją datę urodzenia")]
        [Display(Name = "Data urodzin")]
        public DateTime DataUrodzenia { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wprowadź swój numer PESEL")]
        [StringLength(11,ErrorMessage =("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "PESEL")]
        public string NumerPESEL { get; set; }

        public string IdUzytkownika { get; set; }
        public virtual ApplicationUser Uzytkownik { get; set; }
    }
}
