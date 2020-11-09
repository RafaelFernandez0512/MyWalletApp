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
    public class PayNowPageViewModel:BaseViewModel,IInitialize
    {
        private string numberCreditCard;

        public string NumberCreditCard
        {
            get { return numberCreditCard; }
            set {
                    numberCreditCard = value;
                    numberCreditCard = numberCreditCard ?? string.Empty;
            }
        }

        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public decimal TotalAmount { get; set; }
        public ObservableCollection<Currency> Currencies { get; set; }


        private Currency selectCurrency;

        public Currency SelectCurrency
        {
            get { return selectCurrency; }
            set { selectCurrency = value;
                if (invoce!=null)
                {
                    Task.Run(async () => { TotalAmount = await _multiCurrency.ConvertToOtherCurrency(selectCurrency.Rate, invoce.CurrencyRate, TotalAmount);
                        invoce.CurrencyRate = selectCurrency.Rate;
                    });
                   
                }


            }
        }
        public DelegateCommand LoadCommand { get; set; }

        private string invoceNo;
        private Invoce invoce;
        public string InvoceNo
        {
            get { return invoceNo; }
            set {
                invoceNo = value;
                if (invoceNo != null)
                {
                        invoce = Customer.Invoces.Where(e => $"{e.Id}" == InvoceNo).FirstOrDefault();
                        if (invoce!=null)
                        {
                            TotalAmount = (decimal)invoce?.Amount;
                            SelectCurrency = Currencies.FirstOrDefault(e => e.Id == invoce?.Currency.Id);
                        }


                }
            }
        }

        public PayNowPageViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency) : base(navigationService, data, multiCurrency)
        {
            ExpirationDate = DateTime.Now;
            LoadCommand = new DelegateCommand(async () => await LoadCurrency());
            LoadCommand.Execute();
        }
      async  Task LoadCurrency() {
            Currencies = new ObservableCollection<Currency>( await _multiCurrency.GetCurrencies());
            SelectCurrency = Currencies.FirstOrDefault();
           
        }

        public void Initialize(INavigationParameters parameters)
        {
            var param = parameters[nameof(Payment)] as Customer;
            if (param != null)
            {
                Customer = param;
            }
        }
    }
}
