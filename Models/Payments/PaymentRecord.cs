using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Meal;

namespace design_pattern.Models.Payments
{
    public enum PaymentType{
        Cash, Credit, Check
    }
    public class PaymentRecord
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public PaymentType Type { get; set; }
        public string? CreditCard { get; set; }
        public DateTime? DateOfExpire { get; set; }
        public string? CVV { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}