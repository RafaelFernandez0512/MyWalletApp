using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWalletApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public long NumberCard { get; set; }

        public DateTime CardExpirationDate { get; set; }
        public string CodeCvv { get; set; }
        public string NameCreditCard { get; set; }
        public string TypeCreditCard { get; set; }
        public decimal AmountPay { get; set; }
        public string HideNumberCard
        {
            get
            {
                if(NumberCard>10)
                {
                    var credit = $"{NumberCard}";
                    var lastchars = string.Join("", credit.ToCharArray().OrderByDescending(e => e).Take(credit.Length / 4));
                    return $"****-****-****-{lastchars}";
                }
                return string.Empty;
;


            }
        }

    }
}
