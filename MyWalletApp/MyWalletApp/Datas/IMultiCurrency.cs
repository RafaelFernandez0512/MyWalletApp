using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Datas
{
   public interface IMultiCurrency
    {
        Task<List<Currency>> GetCurrencies();
        void ConvertInvocesToOtherCurrency(List<Invoce> invoces, decimal rateSelected);
        Task<decimal> ConvertToOtherCurrency(decimal rateSelected, decimal originalRate, decimal amount);
    }
}
