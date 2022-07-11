using LiberDent.Data.Data.CMS;
using LiberDent.Data.Data.Slownikowe;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Helpers;

namespace LiberDent.Data.Data.Account
{
    public class DaneLekarza
    {
        //[StringLength(256, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        //[Display(Name = "Zdjęcie")]
        //public string Zdjecie { get; set; }

        [Key]
        public int IdDaneLekarza { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }
        
        [Display(Name = "Tytuł naukowy")]
        public int IdTytulNaukowy { get; set; }
        public virtual TytulNaukowy TytulNaukowy { get; set; }

        [Display(Name = "Stanowisko")]
        public int IdStanowiska { get; set; }
        public virtual Stanowiska Stanowiska { get; set; }

        [Display(Name = "Poziom uprawnień")]
        public int IdPoziomUprawnien { get; set; }
        public virtual PoziomUprawnien PoziomUprawnien { get; set; }

        public string IdUzytkownika { get; set; }
        public virtual ApplicationUser Uzytkownik { get; set; }

        //public string zdjecie { get; set; }

        public virtual ICollection<UmowioneWizyty> UmowioneWizyty { get; set; }

    }
}
