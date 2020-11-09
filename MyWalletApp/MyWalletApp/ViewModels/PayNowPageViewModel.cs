using MyWalletApp.Datas;
using MyWalletApp.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
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

        public DelegateCommand MakePaymentCommand { get=>new DelegateCommand(async()=> {
            if(TotalAmount>0&&!string.IsNullOrEmpty(Cvv)&& ExpirationDate>DateTime.Now && !string.IsNullOrEmpty(NumberCreditCard))
            {
                await _navigationService.GoBackAsync();
                _dialogService.ShowDialog("VerificationDialog", CloseDialogCallback);
            }

        });  }
        void CloseDialogCallback(IDialogResult dialogResult)
        {

        }
        private Currency selectCurrency;

        public Currency SelectCurrency
        {
            get { return selectCurrency; }
            set { selectCurrency = value;
                if (invoce!=null)
                {
                    if (lastRate == 0)
                        lastRate = invoce.CurrencyRate;
                    Task.Run(async () => { TotalAmount = Math.Round(await _multiCurrency.ConvertToOtherCurrency(selectCurrency.Rate, lastRate, TotalAmount),2);
                        lastRate = selectCurrency.Rate;
                    });
                   
                }


            }
        }
        public DelegateCommand LoadCommand { get; set; }
        private decimal lastRate;
        private string invoceNo;
        private Invoce invoce;
        public string InvoceNo
        {
            get { return invoceNo; }
            set {
                invoceNo = value;
                if (invoceNo != null&& !HasBills)
                {
                        invoce = Customer.Invoces.Where(e => $"{e.InvoceNo}" == InvoceNo).FirstOrDefault();
                        TotalAmount = invoce!=null?(decimal)invoce?.Amount:0;
                    if (invoce != null)
                    {
                        SelectCurrency = Currencies.FirstOrDefault(e => e.Id == invoce?.Currency.Id);
                    }


                }
            }
        }
        IDialogService _dialogService;
        public PayNowPageViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency,IDialogService dialogService) : base(navigationService, data, multiCurrency)
        {
            _dialogService = dialogService;
            ExpirationDate = DateTime.Now;
            LoadCommand = new DelegateCommand(async () => await LoadCurrency());
            LoadCommand.Execute();
        }
      async  Task LoadCurrency() {
            Currencies = new ObservableCollection<Currency>( await _multiCurrency.GetCurrencies());
            SelectCurrency = Currencies.FirstOrDefault();
           
        }
        public bool HasBills { get; set; }
        public void Initialize(INavigationParameters parameters)
        {
            var param = parameters[nameof(Payment)] as Customer;
            var invoces = parameters[nameof(Invoce)] as Invoce[];
            var payment = parameters[nameof(PayNowPageViewModel)] as Payment;
            if (param != null)
            {
                Customer = param;
            }
            if (invoces!=null)
            {
                invoce = invoces.FirstOrDefault();
                invoces.ToList().ForEach(async e =>
                {
                    // converter any currency that is different from First invoce.
                    if (e.CurrencyRate != invoce.CurrencyRate)
                        TotalAmount += await _multiCurrency.ConvertToOtherCurrency(invoce.CurrencyRate, e.CurrencyRate, e.Amount);
                    else
                    TotalAmount += e.Amount;
                });
                HasBills = true;
                InvoceNo = string.Join(",", invoces.Select(e=>e.InvoceNo));
                SelectCurrency = Currencies.FirstOrDefault(e => e.Id == invoce.Currency.Id);
            }
            if (payment!=null)
            {
                NumberCreditCard = $"{payment.NumberCard}";
                ExpirationDate = payment.CardExpirationDate;


            }

          

        }
    }
}
