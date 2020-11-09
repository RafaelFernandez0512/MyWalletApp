using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyWalletApp.Models
{
    public class Invoce:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int InvoceNo { get=>1000+Id;  }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate{ get; set; }
        public DateTime InvoceDate { get; set; }
        public string  Description { get; set; }
        public bool IsPaid{ get; set; }
        public Currency Currency { get; set; }
        public decimal CurrencyRate { get; set; }
        public int WeekDay { get => PaymentDate.HasValue ? (int)PaymentDate.GetValueOrDefault().DayOfWeek : -1; }
        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
