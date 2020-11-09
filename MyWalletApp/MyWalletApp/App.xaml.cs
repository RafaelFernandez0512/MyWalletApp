using MyWalletApp.Datas;
using MyWalletApp.Helpers;
using MyWalletApp.ViewModels;
using MyWalletApp.Views;
using Plugin.SharedTransitions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"/SharedTransitionNavigationPage/{NavigationUri.Main}"));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IMultiCurrency, MultiCurrency>();
            containerRegistry.RegisterSingleton<IData, Data>();
            containerRegistry.RegisterForNavigation<SharedTransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, ViewModels.MainPageViewModel>(NavigationUri.Main);
            containerRegistry.RegisterForNavigation<PaymentsHeaderPage>(NavigationUri.PaymentsHeader);
            containerRegistry.RegisterForNavigation<PayNowPage>(NavigationUri.PayNow);
            containerRegistry.RegisterDialog<VerificationDialog, VerificationDialogViewModel>();


        }

    }
}
