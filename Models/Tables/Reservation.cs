using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Meal;

namespace design_pattern.Models.Tables
{
    public enum ReservStatus
    {
        Waiting, CheckedIn, OrderTaken, CheckedOut
    }
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ReservStatus Status { get; set; } = ReservStatus.Waiting;
        public int TableNumber { get; set; }
        public Table Table { get; set; }
        public Order? Order { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }

    }
}