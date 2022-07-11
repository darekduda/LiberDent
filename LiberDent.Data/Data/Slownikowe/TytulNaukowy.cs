using LiberDent.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Slownikowe
{
    public class TytulNaukowy
    {
        [Key]
        public int IdTytulNaukowy { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę tytułu naukowego")]
        [StringLength(50, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Wprowadź skrót od tytułu naukowego")]
        [StringLength(11, ErrorMessage = ("{0} może mieć maksymalnie {1} znaków."))]
        [Display(Name = "Skrót")]
        public string Skrot { get; set; }
        public virtual ICollection<DaneOPersonelu> DaneOPersonelu { get; set; }
    }
}
