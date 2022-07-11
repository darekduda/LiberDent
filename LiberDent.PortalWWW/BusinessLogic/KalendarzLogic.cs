using LiberDent.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.BusinessLogic
{
    public static class KalendarzLogic
    {
        public static DateTime zwiekszMiesiac(DateTime dzien)
        {
            int day = dzien.Day;
            int month = dzien.Month;
            int year =  dzien.Year;

            if (month == 12)
            {
                year = year + 1;
                month = 1;
            }
            else if (dzien.Month == 1 && dzien.Day > 28)
            {
                month = month + 1;
                day = 28;
            }
            else month = month + 1;
            if (DateTime.DaysInMonth(dzien.Year, month) < dzien.Day)
                day = DateTime.DaysInMonth(dzien.Year, dzien.Month + 1);
            return new DateTime(year, month, day);
        }
        public static DateTime zmniejszMiesiac(DateTime dzien)
        {
            int day = dzien.Day;
            int month = dzien.Month;
            int year = dzien.Year;

            if (month == 1)
            {
                year = year -1;
                month = 12;
            }
            else if (dzien.Month == 3 && dzien.Day > 28)
            {
                month = month - 1;
                day = 28;
            }
            else month = month - 1;
            if (DateTime.DaysInMonth(dzien.Year, month) < dzien.Day)
                day = DateTime.DaysInMonth(dzien.Year, dzien.Month - 1);
            return new DateTime(year, month, day);
        }
        public static DateTime zmienDzien(int i, DateTime dzien)
        {
            DateTime data = new DateTime(dzien.Year, dzien.Month, i);
            return data;
        }
        public static DateTime zmniejszZwiekszDzien(int i, DateTime dzien)
        {
            DateTime data = new DateTime(dzien.Year, dzien.Month, dzien.Day);
            if (dzien.Day == DateTime.DaysInMonth(dzien.Year, dzien.Month))
            {
                if (i > 0) data = new DateTime(dzien.Year, dzien.Month + 1, 1);
                else data = new DateTime(dzien.Year, dzien.Month, dzien.Day + i);
            }
            else if (dzien.Day == 1)
            {
                if (i < 0) data = new DateTime(dzien.Year, dzien.Month - 1, DateTime.DaysInMonth(dzien.Year, dzien.Month - 1));
                else data = new DateTime(dzien.Year, dzien.Month, dzien.Day + i);
            }
            else
            {
                data = new DateTime(dzien.Year, dzien.Month, dzien.Day + i);
            }

            return data;
        }
        public static TimeSpan zmienNaGodzine(int i)
        {
            string tmp = i.ToString() + ":00";
            return TimeSpan.Parse(tmp);
        }
        public static int? sprawdzGodzineOtwarcia(DateTime dzien, List<GodzinyOtwarcia> lista)
        {
            int numerDnia = (int)dzien.DayOfWeek;
            if (numerDnia == 0) numerDnia = 7;
            foreach(var item in lista)
            {
                if (item.PozycjaWyswietlania == numerDnia)
                {
                    if (item.GodzinaOtwarciaOd.Contains(':'))
                        return TimeSpan.Parse(item.GodzinaOtwarciaOd + ":00").Hours;
                    else
                        return null;
                }
            }
            return null;
        }
        public static int? sprawdzGodzineZamkniecia(DateTime dzien, List<GodzinyOtwarcia> lista)
        {
            int numerDnia = (int)dzien.DayOfWeek;
            if (numerDnia == 0) numerDnia = 7;
            foreach (var item in lista)
            {
                if (item.PozycjaWyswietlania == numerDnia)
                {
                    if (item.GodzinaOtwarciaOd.Contains(':'))
                        return TimeSpan.Parse(item.GodzinaOtwarciaDo+":00").Hours;
                    else
                        return null;
                }
            }
            return null;
        }
        public static string sprawdzMiesiac(int a)
        {
            switch (a)
            {
                case 1:
                    return "Styczen";
                case 2:
                    return "Luty";
                case 3:
                    return "Marzec";
                case 4:
                    return "Kwiecień";
                case 5:
                    return "Maj";
                case 6:
                    return "Czerwiec";
                case 7:
                    return "Lipiec";
                case 8:
                    return "Sierpień";
                case 9:
                    return "Wrzesień";
                case 10:
                    return "Październik";
                case 11:
                    return "Listopad";
                case 12:
                    return "Grudzień";
                default:
                    return "Blad miesiaca";
            }
        }
    }
}
