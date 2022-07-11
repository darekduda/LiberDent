using LiberDent.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Slownikowe
{
    public class Stanowiska
    {
        [Key]
        public int IdStanowiska { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę stanowiska")]
        [StringLength(40, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Zaznacz czy to stanowisko to lekarz stomatolog?")]
        [Display(Name = "Czy stomatolog")]
        public bool CzyStomatolog { get; set; }
        public virtual ICollection<DaneOPersonelu> DaneOPersonelu { get; set; }
    }
}
