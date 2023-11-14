using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Payments
{
    public class CashPayment : IPaymentStrategy
    {
        public double pay(double amount)
        {
            Console.WriteLine("using Cash " + amount);

            return amount;

        }
    }

}