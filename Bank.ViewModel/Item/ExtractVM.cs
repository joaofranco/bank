using Bank.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class ExtractVM : INotifyPropertyChanged
    {
        private ObservableCollection<BillVM> _bills;
        public ObservableCollection<BillVM> Bills
        {
            get { return _bills; }
            set
            {
                _bills = value;
                RaisePropertyChanged("Bills");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ExtractVM()
        {

        }

        public ExtractVM(bank.dto.ExtractResponse extractResponse)
        {
            Bills = new ObservableCollection<BillVM>();

            foreach (var bills in extractResponse.Data)
            {
                if (bills.bill != null)
                {
                    var billVM = new BillVM();
                    var date = DateTime.Parse(bills.bill.summary.due_date);
                    billVM.MonthDisplay = MonthToDisplay(date.Month);

                    billVM.BillStatus = GetStatus(bills.bill.state);
                    billVM.GerarBoleto = billVM.BillStatus == BillStatus.Closed || billVM.BillStatus == BillStatus.Open;
                    billVM.FinalValue = "R$ " + AmountConverter(bills.bill.summary.total_balance);

                    var expireDate = DateTime.Parse(bills.bill.summary.close_date);
                    billVM.ExpiresDate = "Vencimento " + expireDate.Day + " " + MonthToDisplay(expireDate.Month);

                    billVM.LineItems = new ObservableCollection<ExpenseLineVM>();
                    foreach(var lineItem in bills.bill.line_items)
                    {
                        var item = new ExpenseLineVM();
                        var dateLineItem = DateTime.Parse(bills.bill.summary.due_date);
                        item.Amount = AmountConverter(lineItem.amount);
                        item.PostDate = dateLineItem.Day.ToString() + " " + MonthToDisplay(dateLineItem.Month);
                        item.Title = lineItem.title;
                        billVM.LineItems.Add(item);
                    }

                    Bills.Add(billVM);
                }
            }
        }

        private BillStatus GetStatus(string p)
        {
            if (p.ToLower().Equals("closed")) return BillStatus.Closed;
            if (p.ToLower().Equals("open")) return BillStatus.Open;
            if (p.ToLower().Equals("future")) return BillStatus.Future;
            return BillStatus.Overdue;
        }

        private string AmountConverter(int p)
        {
            return ((float)p / 100).ToString("0.00");
        }

        private string MonthToDisplay(int p)
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
