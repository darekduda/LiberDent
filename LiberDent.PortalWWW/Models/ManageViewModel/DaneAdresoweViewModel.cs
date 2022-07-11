using LiberDent.Data.Data.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Models.ManageViewModel
{
    public class DaneAdresoweViewModel
    {
        [Required]
        public AdresUzytkownika Adres { get; set; }
        public string StatusMessage { get; set; }
    }
}
