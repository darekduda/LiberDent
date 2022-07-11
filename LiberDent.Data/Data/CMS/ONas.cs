using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiberDent.Data.Data.CMS
{
    public class ONas
    {
        [Key]
        public int IdONas { get; set; }
        public string Naglowek { get; set; }
        public string Tresc1 { get; set; }
        public string Tresc2 { get; set; }
    }
}
