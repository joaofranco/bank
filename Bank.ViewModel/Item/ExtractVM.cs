using Bank.Logic;
using Bank.ViewModel.Helpers;
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


        public ExtractVM(bank.dto.ExtractResponse extractResponse)
        {
            Bills = new ObservableCollection<BillVM>();

            foreach (var bills in extractResponse.Data)
            {
                if (bills.bill != null)
                {
                    var billVM = new BillVM();
                    var date = Converters.StringToDate(bills.bill.summary.due_date);
                    billVM.MonthDisplay = Converters.MonthToDisplay(date.Month);

                    billVM.BillStatus = Converters.GetStatus(bills.bill.state);
                    billVM.GerarBoleto = billVM.BillStatus == BillStatus.Closed || billVM.BillStatus == BillStatus.Open;
                    billVM.FinalValue = "R$ " + Converters.AmountConverter(bills.bill.summary.total_balance);

                    var expireDate = Converters.StringToDate(bills.bill.summary.close_date);
                    billVM.ExpiresDate = "Vencimento " + expireDate.Day + " " + Converters.MonthToDisplay(expireDate.Month);

                    billVM.LineItems = new ObservableCollection<ExpenseLineVM>();
                    foreach(var lineItem in bills.bill.line_items)
                    {
                        var item = new ExpenseLineVM();
                        var dateLineItem = Converters.StringToDate(bills.bill.summary.due_date);
                        item.Amount = Converters.AmountConverter(lineItem.amount);
                        item.PostDate = dateLineItem.Day.ToString() + " " + Converters.MonthToDisplay(dateLineItem.Month);
                        item.Title = lineItem.title;
                        billVM.LineItems.Add(item);
                    }

                    Bills.Add(billVM);
                }
            }
        }

        
    }
}
