using MyWalletApp.Datas;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.ViewModels
{
   public class VerificationDialogViewModel:BaseViewModel, IDialogAware
    {

        public bool CanClose { get; set; }=false;
        public DelegateCommand CloseCommand { get => new DelegateCommand(async() =>
        {
           await Task.Delay(1000);
            CanClose = true;
            RequestClose(null);
        }); }

    public VerificationDialogViewModel(INavigationService navigationService, IData data, IMultiCurrency multiCurrency):base(navigationService, data, multiCurrency)
    {

    }

    public event Action<IDialogParameters> RequestClose;

    public bool CanCloseDialog() => CanClose;

    public void OnDialogClosed()
    {

    }

    public void OnDialogOpened(IDialogParameters parameters)
    {

    }
}

}
