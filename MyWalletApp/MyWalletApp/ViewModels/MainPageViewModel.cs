using Microcharts;
using MyWalletApp.Datas;
using MyWalletApp.Helpers;
using MyWalletApp.Models;
using Prism.Commands;
using Prism.Navigation;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWalletApp.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public ObservableCollection<ChartEntry> ChartEntrys { get; set; }
        public DelegateCommand  LoadData { get; set; }
       
        public decimal TotalAmountNotPaid { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public DelegateCommand GoToNavigationCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency) :base(navigationService, data, multiCurrency)
        {
            GoToNavigationCommand = new DelegateCommand(async () =>
            {
                var param = new NavigationParameters();
                param.Add(nameof(Invoce), Customer);
                await _navigationService.NavigateAsync(new Uri($"/{NavigationUri.PaymentsHeader}",UriKind.Relative), param);
            });
            LoadData = new DelegateCommand(async () =>
            {

                await CustomerDetail();
                await LoadCharsEntry();
                TotalAmountNotPaid = Customer.Invoces.Where(e => !e.IsPaid).Sum(e => e.Amount);
                TotalAmountPaid = Customer.Invoces.Where(e => e.IsPaid).Sum(e => e.Amount);
                Customer.Balance = Customer.CreditLimit-TotalAmountPaid;
            });
            LoadData.Execute();
        }
        async Task CustomerDetail() => Customer = new Customer()
        {
            CreditLimit = 1000000,
            Email = "Rafael212@gmail.com",
            Invoces = await _data.GetCustomerInvoce(),
            LastName = "Fernandez",
            Name = "Rafael",
            Phone = 8492209173,
            PaymentMethods = await _data.GetPaymentsSave(),
            Photo = "rafaimage.jpg",
            Id = 1

        };
        async Task<float>GetCustomerInvoces(int weekId)=> (float)await Task.FromResult(Customer.Invoces.Where(e => e.IsPaid && e.WeekDay.Equals(weekId)).Sum(e => e.Amount) - Customer.Balance);
      async  Task LoadCharsEntry()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            ChartEntrys = new ObservableCollection<ChartEntry>();
            for (int i = 1; i < 6; i++)
            {
                var total = await GetCustomerInvoces(i);
                ChartEntrys.Add(new ChartEntry(total)
                {
                    Color = SKColor.Parse("#5E29F2"),
                    ValueLabelColor = SKColor.Parse("#5E29F2"),
                    Label = $"{cultureInfo.DateTimeFormat.GetAbbreviatedDayName((DayOfWeek)i)}",
                    ValueLabel = $"{total:C2}"

                });
            }
        }
       
    }
}
