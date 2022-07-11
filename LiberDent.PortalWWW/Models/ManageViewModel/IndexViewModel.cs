using LiberDent.Data.Data.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Models.ManageViewModel
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public ApplicationUser DaneUzytkownika { get; set; }

    }
}
