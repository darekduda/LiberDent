using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models.Account.AccountViewModel
{
    public class RegisterFirstViewModel
    {
        public List<Stanowiska> Stanowiska { get; set; }
        public List<TytulNaukowy> TytulNaukowy { get; set; }
    }
}
