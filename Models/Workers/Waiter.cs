using design_pattern.Models.Meal;
using design_pattern.Models.Tables;
using design_pattern.Models.Menu;
using design_pattern.Models.Branches;
using Microsoft.EntityFrameworkCore;

namespace design_pattern.Models.Workers

{
    public class Waiter : Worker
    {

        private Order order;
        public Waiter() : base()
        {
            Type = WorkerType.Waiter;
        }
        public Waiter(string Wname, int sal) : base(Wname, sal)
        {
            Type = WorkerType.Waiter;
        }
        public Waiter(string Wname, int sal, Branch b) : base(Wname, sal, b)
        {
            Type = WorkerType.Waiter;
        }

        public void CreateNewOrder(int resId, int TableId, List<List<int>> Meals)
        {
            if (db == null) return;
            Reservation res = db.Reservations.Include(x => x.Table).Where(x => x.Id == resId && x.Table.Number == TableId && x.Status == ReservStatus.CheckedIn).FirstOrDefault();
            Order o = new Order();
            List<MealItem> menuItems = new List<MealItem>();
            for (int i = 0; i < Meals.Count; i++)
            {
                var seat = Meals[i];
                foreach (var item in seat)
                {
                    MenuItem it = db.MenuItems.Where(x => x.Id == item).FirstOrDefault();
                    menuItems.Add(new MealItem() { MenuItemId = item, Price = it.Price, Seat = i, Order=o });
                }
            }
            res.Status = ReservStatus.OrderTaken;
            res.Order = o;
            o.AddMealItems(menuItems);
            db.MealItems.AddRange(menuItems);
            db.Orders.Add(o);
        }

        // public Order TakeOrderToChef()
        // {
        //     order.Status = OrderStatus.Waiting;
        //     return order;
        // }
    }
}