
using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Datas
{
    public class Data : IData
    {
        Random random = new Random();
        IMultiCurrency _multiCurrency;
        public Data(IMultiCurrency multiCurrency)
        {
            _multiCurrency= multiCurrency;
        }
        public async Task<List<Invoce>> GetCustomerInvoce()
        {
            var currencies = await _multiCurrency.GetCurrencies();
            var invoces = new List<Invoce>()
            {
                new Invoce{ 
                  Id=1,
                  Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=10000,
                  Description="AV CLEANANCE GEL LIMP 200 ML",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=false
                },
                new Invoce{
                  Id=2,
                  Currency=currencies.FirstOrDefault(e=>e.Id==2),
                  CurrencyRate = 59.00M,
                  Amount=50000,
                  Description="AV CLEANANCE GEL LIMP 200 ML",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=false
                },
                new Invoce{
                  Id=3,
                   Currency=currencies.FirstOrDefault(e=>e.Id==2),
                  CurrencyRate = 59.00M,
                  Amount=50,
                  Description="Marvel's Spider-Man: Miles Morales Launch Edition - PlayStation 4",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=false
                },
                new Invoce{
                  Id=4,
                  Amount=450,
                  Currency=currencies.FirstOrDefault(e=>e.Id==2),
                  CurrencyRate = 59.00M,
                  Description="NexiGo 2020 Playstation 4 PS4 Slim 1TB consola Holiday Bundle carga Dock Bundle",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=false
                },
                new Invoce{
                  Id=5,
                 Currency=currencies.FirstOrDefault(e=>e.Id==2),
                  CurrencyRate = 59.00M,
                  Amount=40,
                  Description="Cyberpunk 2077 - PlayStation 4",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                  IsPaid=false
                },
                new Invoce{
                  Id=6,
                  Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=5400,
                  Description="Echo Dot (3ra Gen) - Parlante inteligente con Alexa",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=false
                },
                new Invoce{
                  Id=7,
                    Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=10000,
                  PaymentDate = DateTime.Now.AddDays(-3),
                  Description="Echo Dot (3ra Gen) - Parlante inteligente con Alexa - Carbón",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=true
                },
                new Invoce{
                  Id=8,
                  Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=90000,
                  PaymentDate = DateTime.Now.AddDays(-5),
                  Description="Apple MacBook Air (13 pulgadas, 8 GB de RAM, 256 GB de almacenamiento SSD",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=true
                },
                new Invoce{
                  Id=9,
                  Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=120000,
                  PaymentDate = DateTime.Now.AddDays(-4),
                  Description="Apple MacBook Pro",
                  InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=true
                },
                new Invoce{
                  Id=10,
                  Currency=currencies.FirstOrDefault(e=>e.Id==1),
                  CurrencyRate=1,
                  Amount=6000,
                  PaymentDate = DateTime.Now.AddDays(-2),
                  Description="JBL TUNE 500BT",
                 InvoceDate=DateTime.Parse("10/10/2020"),
                 IsPaid=true
                },
            };
            return await Task.FromResult(invoces);
        }

        public async Task<List<Payment>> GetPaymentsSave() => await Task.FromResult(new List<Payment>() {
        new Payment(){
       AmountPay=20000,
        CardExpirationDate=DateTime.Parse("11/12/2024"),
        Id=1,
        NameCreditCard="RAFAEL FERNANDEZ",
        NumberCard=4024007144541165,
        TypeCreditCard="Visa"
        },
        new Payment(){
        AmountPay=153400,
        CardExpirationDate=DateTime.Parse("04/12/2028"),
        Id=1,
        NameCreditCard="RAFAEL FERNANDEZ",
        NumberCard=373799078629736,
        TypeCreditCard="American expresse"
        } });

    }
}
