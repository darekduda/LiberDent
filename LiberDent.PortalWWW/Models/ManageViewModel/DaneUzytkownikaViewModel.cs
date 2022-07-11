using LiberDent.Data.Data.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Models.ManageViewModel
{
    public class DaneUzytkownikaViewModel
    {
        //[Required]
        //public string Imie { get; set; }
        //[Required]
        //public string Nazwisko { get; set; }
        //[Required]
        //public DateTime DataUrodzenia { get; set; }

        //public string StatusMessage { get; set; }
        //[PersonalData]
        //[Required(ErrorMessage = "Wpisz swoje imię")]
        //[StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Imię")]
        //public string Imie { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "Wpisz swoje nazwisko")]
        //[StringLength(70, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Nazwisko")]
        //public string Nazwisko { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "Wprowadź swoją datę urodzenia")]
        //[Display(Name = "Data urodzin")]
        //public DateTime DataUrodzenia { get; set; }
        [Required]
        public DaneUzytkownika Dane { get; set; }
        public string StatusMessage { get; set; }
    }
}
