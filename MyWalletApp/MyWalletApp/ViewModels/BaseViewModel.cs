using MyWalletApp.Datas;
using MyWalletApp.Helpers;
using MyWalletApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyWalletApp.ViewModels
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService _navigationService;
       protected IData _data;
        protected IMultiCurrency _multiCurrency;
        public Customer Customer { get; set; }
        public DelegateCommand  BackNavigationCommand { get => new DelegateCommand(async() =>await _navigationService.GoBackAsync()); }
        public DelegateCommand GoToPayNowCommand { get; set; }
        public BaseViewModel(INavigationService navigationService,IData data,IMultiCurrency multiCurrency)
        {
            _navigationService = navigationService;
            _data = data;
            _multiCurrency = multiCurrency;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
