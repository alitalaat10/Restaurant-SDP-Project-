using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Data;
using design_pattern.Models.Branches;

namespace design_pattern.Models.Workers
{

    public enum WorkerType
    {
        Manager, Chef, Waiter, Receptionist, Cachier
    }
    public abstract class Worker
    {
        public int Id { get; set; }
        public int salary { get; set; }
        public String workerName { get; set; }
        public WorkerType Type { get; set; }
        public string BranchName { get; set; }
        public Branch Branch { get; set; }
        protected AppDbContext db;
        public void SetConnection(AppDbContext db)
        {
            this.db = db;
        }
        public Worker()
        {
        }
        public Worker(String Wname, int sal)
        {
            salary = sal;
            workerName = Wname;
        }
        public Worker(String Wname, int sal, Branch branch)
        {
            salary = sal;
            workerName = Wname;
            this.Branch = branch;
        }
    }
}