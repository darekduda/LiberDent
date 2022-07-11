using LiberDent.Data.Data.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models.Account.ManageViewModel
{
    public class DaneUzytkownikaViewModel
    {
        [Required]
        public DaneUzytkownika Dane { get; set; }
    }
}
