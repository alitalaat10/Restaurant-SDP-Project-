using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Branches;
using design_pattern.Models.Meal;

namespace design_pattern.Models.Workers
{
    public class Chef : Worker
    {
        public Chef() : base()
        {
            Type = WorkerType.Chef;
        }
        public Chef(string Wname, int sal) : base(Wname, sal)
        {
            Type = WorkerType.Chef;
        }
        public Chef(string Wname, int sal, Branch branch) : base(Wname, sal, branch)
        {
            Type = WorkerType.Chef;
        }

        public bool FinishOrder(int orderId)
        {
            if(db == null) return false;
            // Order o = db.Orders.Where(x=>x.Id == orderId).FirstOrDefault();
            // if(o == null) return false;
            // o.Status = OrderStatus.Finished;
            return true;
        }
    }
}