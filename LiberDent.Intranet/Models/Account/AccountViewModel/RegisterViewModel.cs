using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models.Account.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public DaneLekarza Dane { get; set; }

        public List<Stanowiska> Stanowiska { get; set; }
        public List<TytulNaukowy> TytulNaukowy { get; set; }
        public List<PoziomUprawnien> PoziomUprawnienLista { get; set; }
        public int IdPoziomUprawnien { get; set; }
    }
}
