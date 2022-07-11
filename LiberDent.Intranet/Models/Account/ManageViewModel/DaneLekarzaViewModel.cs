using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models.Account.ManageViewModel
{
    public class DaneLekarzaViewModel
    {
        [Required]
        public DaneLekarza DaneLekarza { get; set; }
        public List<Stanowiska> Stanowiska { get; set; }
        public List<TytulNaukowy> TytulNaukowy { get; set; }
    }
}
