using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Branches;

namespace design_pattern.Models.Workers
{
   public class WorkerFactory
   {
      public Worker addnewWorker(WorkerType type , String name , int Salary)
      {
         if(type == WorkerType.Chef)
         {
            return new Chef(name, Salary);
         }
         else if(type == WorkerType.Cachier)
         {
            return new Cachier(name, Salary);
         }
         else if(type == WorkerType.Receptionist)
         {
            return new Receptionist(name, Salary);
         }
         else if(type == WorkerType.Waiter)
         {
            return new Waiter(name, Salary);
         }
         else return null;
      }
   }
}