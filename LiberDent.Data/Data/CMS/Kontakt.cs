using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class Kontakt
    {
        [Key]
        public int IdKontaktu { get; set; }

        [MaxLength(20, ErrorMessage ="Nagłówek powinien zawierać maksymalnie 20 znaków")]
        [Display(Name ="Nagłówek")]
        public string TytułKontakt { get; set; }

        [Required(ErrorMessage = "Wpisz numer telefonu")]
        [MaxLength(12, ErrorMessage = "Numer telefonu powinien zawierać maksymalnie 12 znaków")]
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }

        [Required(ErrorMessage = "Wpisz do kogo numer należy")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna zawierać maksymalnie 30 znaków")]
        [Display(Name = "Nazwa dla numeru")]
        public string NazwaTelefonu { get; set; }

        [Required(ErrorMessage = "Wpisz dodatkową treść")]
        [Column(TypeName ="nvarchar(max)")]
        [Display(Name = "Dodatkowa treść")]
        public string TrescKontaktu { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję na ktorej ma być wyświetlony")]
        [Display(Name = "Numer pozycji")]
        public int PozycjaWyswietlania { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
