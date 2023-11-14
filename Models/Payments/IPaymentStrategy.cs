using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Payments
{
    public interface IPaymentStrategy
    {
            
            double pay(double amount);

    }
}