using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Payments
{
    public class CheckPayment : IPaymentStrategy
    {
        private String customerName  { get; set; }
        private DateTime dateOfExpire  { get; set; }
        public CheckPayment(String name, DateTime dateOfExpire)
        {
            this.customerName = name;
            this.dateOfExpire = dateOfExpire;
        }
        public CheckPayment()
        {
        }
        public double pay(double amount)
        {
            Console.WriteLine("using Check " + amount);

            return amount;
        }

    }

}