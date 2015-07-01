using Bank.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime;

namespace Bank.ViewModel
{
    public class MapPageVM : INotifyPropertyChanged
    {
        private ExtractVM _extractVM;
        public ExtractVM ExtractVM {
             get { return _extractVM; }
              set
              {
                _extractVM= value;
                RaisePropertyChanged("ExtractVM");
              }
        }

        private bool _isBusy;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged("IsBusy"); } }
        private bool _isError;
        public bool IsError { get { return _isError; } set { _isError = value; RaisePropertyChanged("IsError"); } }
        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; RaisePropertyChanged("ErrorMessage"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public async Task InitializeAsync()
        {
            IsError = false;
            IsBusy = true;
            await GetExtract();
            IsBusy = false;
        }

        private async Task GetExtract()
        {
            ExtractVM = null; 
            
            try
            {
                var extractResponse = await Helper.Current.Api.GetExtract();

                if(extractResponse.Status == 200)
                {
                    ExtractVM = new ViewModel.ExtractVM(extractResponse);
                }
                else
                    HandleError(extractResponse);
            }
            catch(Exception ex)
            {
                IsError = true;
                ErrorMessage = "Parece que você está sem internet! Por favor,verifique a sua conexão.";
            }
        }

        private void HandleError(bank.dto.ExtractResponse extractResponse)
        {
            IsError = true;
            if(extractResponse.Status >= 400 && extractResponse.Status < 500)
            {
                ErrorMessage = "Houve algum erro com o seu pedido";
            }
            else if(extractResponse.Status >= 500 && extractResponse.Status < 600)
            {
                ErrorMessage = "Desculpe, estamos enfrentando problemas técnicos. Por favor, tente novamente mais tarde.";
            }
            else
            {
                ErrorMessage = "Erro nao identificado";
            }
        }
    }
}
