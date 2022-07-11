using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.Slownikowe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class UmowioneWizyty
    {
        [Key]
        public int IdUmowioneWizyty { get; set; }

        public DateTime DataWizyty { get; set; }
        public TimeSpan GodzinaWizyty { get; set; }
        public string IdApplicationUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int IdLekarza { get; set; }
        public virtual DaneLekarza DaneLekarza { get; set; }
        public int IdRodzajeWizyty { get; set; }
        public virtual RodzajeWizyty RodzajeWizyty { get; set; }
        public bool CzyPacjentByl { get; set; }
    }
}
