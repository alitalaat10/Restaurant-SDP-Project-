using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Branches;
using design_pattern.Models.Menu;
using Microsoft.EntityFrameworkCore;

namespace design_pattern.Models.Workers
{  //should be factory ask him which type of worker
   public class Manager : Worker
   {

      private WorkerFactory wf;

      private MenuSection menuSection { get; set; }
      public Manager() : base()
      {
         wf = new WorkerFactory();
         Type = WorkerType.Manager;
      }
      public Manager(string Wname, int sal, Branch b) : base(Wname, sal, b)
      {
         wf = new WorkerFactory();
         Type = WorkerType.Manager;
      }
      public void addnewWorker(WorkerType type, String name, int Salary)
      {
         if (db == null) return;
         Worker w = wf.addnewWorker(type, name, salary);
         w.BranchName = BranchName;
         switch (type)
         {
               case WorkerType.Chef:
                  db.Chefs.Add((Chef)w);
                  break;
               case WorkerType.Cachier:
                  db.Cachiers.Add((Cachier)w);
                  break;
               case WorkerType.Receptionist:
                  db.Receptionists.Add((Receptionist)w);
                  break;
               case WorkerType.Waiter:
                  db.Waiters.Add((Waiter)w);
                  break;
         }
      }

      public void AddSection(MenuSection section)
      {
         if (db == null) return;
         section.BranchName = BranchName;
         db.MenuSections.Add(section);
      }
      public bool EditMenuSection(int id, MenuSection newsec, List<MenuItem> items)
      {
         if (db == null) return false;
         MenuSection sec = db.MenuSections.Include(x => x.Items).Where(b => b.Id == id && b.BranchName == this.BranchName).FirstOrDefault();
         if (sec == null) return false;
         sec.Name = newsec.Name;
         sec.Desc = newsec.Desc;
         List<int> oldIds = new List<int>();
         for (int i = 0; i < items.Count; i++)
         {
            MenuItem item = items[i];
            Console.WriteLine(item.Id);
            if (item.Id > 0)
            {

               oldIds.Add(item.Id);
               MenuItem oldItem = db.MenuItems.Where(x => x.Id == item.Id).FirstOrDefault();
               if (oldItem != null)
               {
                  oldItem.Name = item.Name;
                  oldItem.Desc = item.Desc;
                  oldItem.Price = item.Price;
               }
            }
            else
            {
               MenuItem newitem = new MenuItem(item.Name, item.Desc, item.Price);
               sec.Add(newitem);
            }
         }
         db.MenuItems.RemoveRange(db.MenuItems.Where(x => (!oldIds.Contains(x.Id)) && x.MenuSectionId == id));
         return true;
      }
      public bool RemoveSection(int id)
      {
         if (db == null) return false;
         MenuSection sec = db.MenuSections.Where(b => b.Id == id && b.BranchName == this.BranchName).FirstOrDefault();
         if (sec == null) return false;
         db.MenuSections.Remove(sec);
         return true;
      }
   }
}