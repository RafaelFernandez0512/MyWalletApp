using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayNowPage : ContentPage
    {
        public PayNowPage()
        {
            InitializeComponent();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await CreditCardView.RotateYTo(90, 200);
                FrontCreditCard.IsVisible = !e.IsFocused;
                await CreditCardView.RotateYTo(0, 200);
            });
        }
    }
}