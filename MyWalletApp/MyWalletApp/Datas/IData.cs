using MyWalletApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletApp.Datas
{
   public interface IData
    {
        Task<List<Invoce>> GetCustomerInvoce();
        Task<List<Payment>> GetPaymentsSave();

    }
}
