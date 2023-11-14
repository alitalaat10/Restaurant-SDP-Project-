using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Payments
{
    public class CreditCardPayment : IPaymentStrategy
    {
        private String customerName  { get; set; }
        
        private String cardNumber  { get; set; }

        [Range(3,3, ErrorMessage = "CVV must be 3 digits")]
        private string cvv  { get; set; }

        private DateTime dateOfExpire  { get; set; }
        public CreditCardPayment(String Name, String cardNumber, string cvv, DateTime dateOfExpire)
        {

            this.customerName = Name;
            this.cardNumber = cardNumber;
            this.cvv = cvv;
            this.dateOfExpire = dateOfExpire;

        }
        public CreditCardPayment()
        {
        }
        public double pay(double amount)
        {

            Console.WriteLine("using Credit " + amount);


            return amount;
        }
    }
}