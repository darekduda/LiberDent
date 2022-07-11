using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using LiberDent.Data.Data.Account;

namespace LiberDent.Data.Data.Slownikowe
{
    public class PoziomUprawnien
    {
        [Key]
        public int IdPoziomUprawnien { get; set; }
        public int NumerUprawnien { get; set; }
        public string OpisUprawnien { get; set; }
        public virtual ICollection<DaneLekarza> DaneLekarza { get; set; }
    }
}
