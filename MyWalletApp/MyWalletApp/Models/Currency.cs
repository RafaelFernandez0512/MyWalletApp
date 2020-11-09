using System;
using System.Collections.Generic;
using System.Text;

namespace MyWalletApp.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

    }
}
