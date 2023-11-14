using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using design_pattern.Models.Menu;

namespace design_pattern.Models.Payments
{
    public class PaymentContext
    {

        private List<MenuCmp> items;

        private IPaymentStrategy paymentStrategy;

        private double balance;
        public PaymentContext(double balance)
        {
            this.balance = balance;
            this.items = new List<MenuCmp>();
        }
        private double calculateTotal()
        {
            double sum = 0.0;

            foreach (var item in items)
            {

                sum += item.Price;

            }
            return sum;
        }

        public MenuItem addItem(MenuItem menuItem)
        {
            this.items.Add(menuItem);
            return menuItem;
        }

        public void PayAmount(IPaymentStrategy paymentMethods)
        {
            double amount = calculateTotal();
            //    paymentMethods =new ProxyPayments(balance);
            if (amount > balance)
            {
                Console.WriteLine("No Enough Balance  " + balance);
            }
            else
            {
                paymentMethods.pay(amount);
            }


        }
    }
}