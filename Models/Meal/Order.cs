

using design_pattern.Models.Menu;
using design_pattern.Models.Tables;

namespace design_pattern.Models.Meal
{

    public enum OrderStatus
    {
        Waiting, Finished
    }
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Waiting;
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public List<MealItem> MealItems { get; set; } = new List<MealItem>();

        public Order()
        {
        }

        public void AddMealItems(List<MealItem> items)
        {
            MealItems.AddRange(items);
        }

        public double TotalPrice
        {
            get
            {
                double cost = 0;
                foreach (var mealitem in MealItems)
                {
                    cost += mealitem.Price;
                }
                return cost;
            }
        }
    }
}