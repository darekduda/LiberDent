using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models.Account.ManageViewModel
{
    public class InfoOPacjecieViewModel
    {
        public ApplicationUser Pacjent { get; set; }
        public UmowioneWizyty Wizyta { get; set; }
    }
}
