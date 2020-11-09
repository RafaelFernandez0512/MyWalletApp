using MyWalletApp.Datas;
using MyWalletApp.Helpers;
using MyWalletApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace MyWalletApp.ViewModels
{
   public class PaymentsHeaderPageViewModel:BaseViewModel,IInitialize
    {
        private Invoce selectionItem;

        public Invoce SelectionItem
        {
            get { return selectionItem; }
            set
            {
                selectionItem = value;
                if (selectionItem!=null)
                {
                    Invoces.ForEach(e => e.IsSelected = selectionItem.Id.Equals(e.Id)? !selectionItem.IsSelected : e.IsSelected);
                    selectionItem =null;
                }
            }
        }

        public Payment SelectPaymentSave { get; set; }
        public ObservableCollection<Invoce> Invoces { get; set; }
        public DelegateCommand ShowAllInvoceCommand { get => new DelegateCommand(()=>
        {
            Invoces = new ObservableCollection<Invoce>(Customer.Invoces);
        }); 
        }
        public ObservableCollection<Payment> Payments  { get; set; }
        public PaymentsHeaderPageViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency) : base(navigationService, data, multiCurrency)
        {
            GoToPayNowCommand = new DelegateCommand(async () =>
            {
               var invoceSelect = Invoces.Where(e => e.IsSelected).ToArray();
                var param = new NavigationParameters();
                if (invoceSelect != null && invoceSelect.Count() > 0)
                    param.Add(nameof(Invoce), invoceSelect);
                if (SelectPaymentSave != null)
                    param.Add(nameof(PayNowPageViewModel), SelectPaymentSave);
                await _navigationService.NavigateAsync(new Uri($"/{NavigationUri.PayNow}", UriKind.Relative), param);
            });
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
