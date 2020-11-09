using MyWalletApp.Datas;
using MyWalletApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.ViewModels
{
   public class PaymentsHeaderPageViewModel:BaseViewModel,IInitialize
    {
        public ObservableCollection<Invoce> Invoces { get; set; }
        public DelegateCommand ShowAllInvoceCommand { get => new DelegateCommand(()=>
        {
            Invoces = new ObservableCollection<Invoce>(Customer.Invoces);


            }); }

        public ObservableCollection<Payment> Payments  { get; set; }
        public PaymentsHeaderPageViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency) : base(navigationService, data, multiCurrency)
        {

        }

        public void Initialize(INavigationParameters parameters)
        {
            var customer = parameters[nameof(Invoce)] as Customer;
            if (customer != null)
            {
                Customer = customer;
                Invoces = new ObservableCollection<Invoce>(Customer.Invoces.Take(2));
                Payments = new ObservableCollection<Payment>(customer.PaymentMethods);
            }
        }
    }
}
