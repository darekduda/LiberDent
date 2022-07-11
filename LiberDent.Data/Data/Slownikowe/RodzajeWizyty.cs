using LiberDent.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.Slownikowe
{
    public class RodzajeWizyty
    {
        [Key]
        public int IdRodzajeWizyty { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<UmowioneWizyty> UmowioneWizyty { get; set; }
    }
}
