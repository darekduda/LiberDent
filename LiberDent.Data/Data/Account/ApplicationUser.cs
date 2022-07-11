using LiberDent.Data.Data.CMS;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Account
{
    public class ApplicationUser : IdentityUser
    {
        //[PersonalData]
        //[Required(ErrorMessage = "Wpisz swoje imię")]
        //[StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Imię")]
        //public string Imie { get; set; }

        //[PersonalData]
        //[StringLength(50, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Drugie imię")]
        //public string DrugieImie { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "Wpisz swoje nazwisko")]
        //[StringLength(70, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Nazwisko")]
        //public string Nazwisko { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "Wpisz swój numer telefonu")]
        //[StringLength(17, ErrorMessage = "{0} może mieć maksymalnie {1} znaków.")]
        //[Display(Name = "Numer telefonu")]
        //public override string PhoneNumber { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "Wprowadź swoją datę urodzenia")]
        //[Display(Name = "Data urodzin")]
        //public DateTime DataUrodzenia { get; set; }

        [PersonalData]
        public virtual AdresUzytkownika Adres { get; set; }

        [PersonalData]
        public virtual DaneUzytkownika Dane { get; set; }

        public virtual DaneLekarza DaneLekarza { get; set; }

        public bool CzyLekarz { get; set; }

        public virtual ICollection<UmowioneWizyty> UmowioneWizyty { get; set; }

    }
}
