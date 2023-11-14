using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Menu;

namespace design_pattern.Models.Meal
{
    public class MealItem
    {
        public int Id { get; set; }
        public MenuItem Item { get; set; }
        public int MenuItemId { get; set; }
        public Order Order { get; set; }
        public int Seat { get; set; }
        public double Price { get; set; }
    }
}