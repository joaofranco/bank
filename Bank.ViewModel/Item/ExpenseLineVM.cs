using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class ExpenseLineVM : INotifyPropertyChanged
    {
        //Header
        private string _postDate;
        public string PostDate { get { return _postDate; } set { _postDate = value; RaisePropertyChanged("PostDate"); } }

        //Color Square
        private string _title;
        public string Title { get { return _title; } set { _title = value; RaisePropertyChanged("Title"); } }

        private string _amount;
        public string Amount { get { return _amount; } set { _amount = value; RaisePropertyChanged("Amount"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
