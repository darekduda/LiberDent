using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class DaneOPersonelu
    {
        [Key]
        public int IdDaneOPersonelu { get; set; }

        [Required(ErrorMessage = "Wprowadź imię")]
        [StringLength(30, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(30, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [StringLength(256, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Zdjęcie")]
        public string Zdjecie { get; set; }

        [Required(ErrorMessage = "Wprowadź opis")]
        [Display(Name = "Opis")]
        public string Opis { get; set; }
        //[ForeignKey("Stanowiska")]
        //public int IdStanowiska { get; set; }
        //public virtual Stanowiska Stanowiska { get; set; }
        [Required(ErrorMessage = "Wprowadź tytuł naukowy")]
        [Display(Name = "Tytuł naukowy")]
        public int IdTytulNaukowy { get; set; }
        public virtual TytulNaukowy TytulNaukowy { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę stanowiska")]
        [Display(Name = "Stanowisko")]
        public int IdStanowiska { get; set; }
        public virtual Stanowiska Stanowiska { get; set; }
    }
}
