using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class BillVM : INotifyPropertyChanged
    {
        //Header
        private string _monthDisplay;
        public string MonthDisplay { get { return _monthDisplay; } set { _monthDisplay = value; RaisePropertyChanged("MonthDisplay"); } }

        //Color Square
        private string _finalValue;
        public string FinalValue { get { return _finalValue; } set { _finalValue = value; RaisePropertyChanged("FinalValue"); } }

        private string _expiresDate;
        public string ExpiresDate { get { return _expiresDate; } set { _expiresDate = value; RaisePropertyChanged("ExpiresDate"); } }

        private string _closeDate;
        public string CloseDate { get { return _closeDate; } set { _closeDate = value; RaisePropertyChanged("CloseDate"); } }

        //Middle Area

        private bool _showGerarBoleto;
        public bool GerarBoleto { get { return _showGerarBoleto; } set { _showGerarBoleto = value; RaisePropertyChanged("GerarBoleto"); } }

        //Table Data
        private ObservableCollection<ExpenseLineVM> _lineItems;
        public ObservableCollection<ExpenseLineVM> LineItems { get { return _lineItems; } set { _lineItems = value; RaisePropertyChanged("LineItems"); } }

        //others
        private BillStatus _billStatus;
        public BillStatus BillStatus { get { return _billStatus; } set { _billStatus = value; RaisePropertyChanged("BillStatus"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }

    public enum BillStatus
    {
        Overdue,
        Closed,
        Open,
        Future
    }

}
