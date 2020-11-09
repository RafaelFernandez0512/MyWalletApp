using System;
using System.Collections.Generic;
using System.Text;

namespace MyWalletApp.Models
{
    public class Invoce
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate{ get; set; }
        public DateTime InvoceDate { get; set; }
        public string  Description { get; set; }
        public bool IsPaid{ get; set; }
        public Currency Currency { get; set; }
        public decimal CurrencyRate { get; set; }
        public int WeekDay { get => PaymentDate.HasValue ? (int)PaymentDate.GetValueOrDefault().DayOfWeek : -1; }
    }
}
