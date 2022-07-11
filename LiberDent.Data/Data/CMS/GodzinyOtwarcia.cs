using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class GodzinyOtwarcia
    {
        [Key]
        public int IdGodzinyOtwarcia { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę dnia")]
        [MaxLength(20, ErrorMessage = "Nazwa dnia powinna zawierać maksymalnie 20 znaków")]
        [Display(Name = "Dzień")]
        public string Dzien { get; set; }

        [Required(ErrorMessage = "Wpisz od której w dany dzień czynny jest gabinet")]
        [MaxLength(12, ErrorMessage = "Godzina otwarcia powinna zawierać maksymalnie 12 znaków")]
        [Display(Name = "Godzina otwarcia od")]
        public string GodzinaOtwarciaOd { get; set; }

        [Required(ErrorMessage = "Wpisz do której w dany dzień czynny jest gabinet")]
        [MaxLength(12, ErrorMessage = "Godzina otwarcia powinna zawierać maksymalnie 12 znaków")]
        [Display(Name = "Godzina otwarcia Do")]
        public string GodzinaOtwarciaDo { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję na ktorej ma być wyświetlony")]
        [Display(Name ="Numer pozycji")]
        public int PozycjaWyswietlania { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
