using LiberDent.Data.Data.CMS;
using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Models
{
    public class DaneOPersoneluViewModel
    {
        public DaneOPersonelu DaneOPersonelu { get; set; }
        public ICollection<TytulNaukowy> TytulyNaukowe { get; set; }
        public ICollection<Stanowiska> Stanowiska { get; set; }
    }
}
