using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.CMS;
using LiberDent.Data.Data.Slownikowe;
using LiberDent.PortalWWW.BusinessLogic;
using LiberDent.PortalWWW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Models.HomeViewModel
{
    public class UmowWizyteViewModel
    {
        private DateTime _WybranyDzien;
        public DateTime WybranyDzien 
        {
            get
            {
                return _WybranyDzien;
            }
            set
            {
                if(_WybranyDzien!=value)
                {
                    _WybranyDzien = value;
                }
                int tmp = (int) new DateTime(WybranyDzien.Year, WybranyDzien.Month, 1).DayOfWeek;
                if (tmp > 0) PierwszyDzienMiesiaca = tmp;
                else PierwszyDzienMiesiaca = 7;
                tmp =(int) new DateTime(WybranyDzien.Year, WybranyDzien.Month, 1).AddMonths(1).AddDays(-1).DayOfWeek;
                if (tmp > 0) OstatniDzienMiesiaca = tmp;
                else OstatniDzienMiesiaca = 7;
                DniWWybranymMiesiacu = DateTime.DaysInMonth(WybranyDzien.Year, WybranyDzien.Month);
                NazwaMiesiaca = KalendarzLogic.sprawdzMiesiac(WybranyDzien.Month);
                NastepnyMiesiac = KalendarzLogic.zwiekszMiesiac(WybranyDzien);
                AktualnaGodzina = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                AktualnyDzien = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }
        public int PierwszyDzienMiesiaca { get; set; }
        public int DniWWybranymMiesiacu { get; set; }
        public int OstatniDzienMiesiaca { get; set; }
        public DateTime NastepnyMiesiac { get; set; }

        public string NazwaMiesiaca { get; set; }
        public string IdLekarza { get; set; }
        public List<DaneLekarza> ListaLekarzy { get; set; }
        public TimeSpan GodzinaWizyty { get; set; }
        public TimeSpan AktualnaGodzina { get; set; }
        public DateTime AktualnyDzien { get; set; }
        public int IdRodzajWizyty { get; set; }
        public List<RodzajeWizyty> ListaRodzajeWizyt { get; set; }
        public List<UmowioneWizyty> UmowioneWizyty { get; set; }
        public List<GodzinyOtwarcia> GodzinyOtwarciaLista { get; set; }
        public string StatusMessage { get; set; }
        //private string sprawdzMiesiac(int a)
        //{
        //    switch (a)
        //    {
        //        case 1:
        //            return "Styczen";
        //        case 2:
        //            return "Luty";
        //        case 3:
        //            return "Marzec";
        //        case 4:
        //            return "Kwiecień";
        //        case 5:
        //            return "Maj";
        //        case 6:
        //            return "Czerwiec";
        //        case 7:
        //            return "Lipiec";
        //        case 8:
        //            return "Sierpień";
        //        case 9:
        //            return "Wrzesień";
        //        case 10:
        //            return "Październik";
        //        case 11:
        //            return "Listopad";
        //        case 12:
        //            return "Grudzień";
        //        default:
        //            return "Blad miesiaca";
        //    }
        //}
        //public DateTime zwiekszMiesiac(DateTime dzien)
        //{
        //    DateTime data = new DateTime(dzien.Year, dzien.Month, dzien.Day);
        //    if (dzien.Month == 12)
        //    {
        //        data = new DateTime(dzien.Year + 1, 1, dzien.Day);
        //    }
        //    else
        //    {
        //        data = new DateTime(dzien.Year, dzien.Month + 1, dzien.Day);
        //    }
        //    return data;
        //}
        //public UmowWizyteViewModel zwiekszMiesiac2(DateTime dzien)
        //{
        //    DateTime data = new DateTime(dzien.Year, dzien.Month + 1, dzien.Day);
        //    return new UmowWizyteViewModel
        //    {
        //        IdLekarza = this.IdLekarza,
        //        WybranyDzien = data
        //    };
        //}
    }
}
