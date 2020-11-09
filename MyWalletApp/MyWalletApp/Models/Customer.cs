using System;
using System.Collections.Generic;
using System.Text;

namespace MyWalletApp.Models
{
   public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; set; }
        public string Photo { get; set; }
        public List<Invoce> Invoces { get; set; }
 
        public List<Payment> PaymentMethods { get; set; }
    }
}
