using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class Powitanie
    {
        [Key]
        public int IdPowitania { get; set; }

        [Required(ErrorMessage = "Wpisz Nagłówek powitalny")]
        [MaxLength(150, ErrorMessage = "Nagłówek powinien zawierać maksymalnie 150 znaków")]
        [Display(Name = "Nagłówek")]
        public string NaglowekPowitalny { get; set; }

        [Required(ErrorMessage = "Wpisz treść powitalną")]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Treść główna")]
        public string TrescPowitalna1 { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Treść dodatkowa")]
        public string TrescPowitalna2 { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
