using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel.Helpers
{
    public class Converters
    {
        public static DateTime StringToDate(string date)
        {
            return DateTime.Parse(date);
        }

        public static BillStatus GetStatus(string p)
        {
            if (p.ToLower().Equals("closed")) return BillStatus.Closed;
            if (p.ToLower().Equals("open")) return BillStatus.Open;
            if (p.ToLower().Equals("future")) return BillStatus.Future;
            return BillStatus.Overdue;
        }

        public static string AmountConverter(int p)
        {
            return ((float)p / 100).ToString("0.00");
        }

        public static string MonthToDisplay(int p)
        {
            //TODO internacionalizar e todos meses
            if (p == 1) return "JAN";
            if (p == 2) return "FEV";
            if (p == 3) return "MAR";
            if (p == 4) return "ABR";
            if (p == 5) return "MAI";
            if (p == 6) return "JUN";
            if (p == 7) return "JUL";
            if (p == 8) return "AGO";
            if (p == 9) return "SET";
            if (p == 10) return "OUT";
            if (p == 11) return "NOV";
            if (p == 12) return "DEZ";
            return "MES";
        }

    }
}
