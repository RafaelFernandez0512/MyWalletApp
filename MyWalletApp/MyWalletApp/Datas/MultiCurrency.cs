using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Datas
{
    public class MultiCurrency : IMultiCurrency
    {
        public void ConvertInvocesToOtherCurrency(List<Invoce> invoces, decimal rateSelected)
        {
            invoces.ForEach(async e => {
                e.Amount =await ConvertToOtherCurrency(rateSelected,e.CurrencyRate,e.Amount);
                e.CurrencyRate = rateSelected;
            });
        }

        public Task<decimal> ConvertToOtherCurrency(decimal rateSelected, decimal originalRate, decimal amount)
        {
            return Task.FromResult(Math.Round((decimal)(rateSelected > originalRate ? amount / (rateSelected / originalRate) : amount * (originalRate / rateSelected)), 2));
        }

        public Task<List<Currency>> GetCurrencies()
        {
            var currencies = new List<Currency>()
            {
                new Currency{
                Symbol="RD",
                Id=1,
                Name="Peso Dominicano",
                Rate=1
                },
                new Currency{
                Symbol="US",
                Id=2,
                Name="Dollar",
                Rate=59.00M
                },
                new Currency{
                Symbol="€",
                Id=3,
                Name="Euro",
                Rate=69.41M
                },
            };
            return Task.FromResult(currencies);
        }
    }
}
