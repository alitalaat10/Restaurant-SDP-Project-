
using design_pattern.Models.Menu;

namespace design_pattern.Models.Meal
{
    public class Meal
    {
        public int Id { get; set; }
        public List<MenuItem> Items { get; set; }
        public Order Order { get; set; }

        public double TotalPrice
        {
            get
            {
                double cost = 0;
                foreach (var item in Items)
                {
                    cost += item.Price;
                }
                return cost;
            }
        }
        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }
    }
}