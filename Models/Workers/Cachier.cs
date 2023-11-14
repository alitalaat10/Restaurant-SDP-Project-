using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Branches;

namespace design_pattern.Models.Workers
{


    public class Cachier : Worker
    {
        public Cachier() : base()
        {
            Type = WorkerType.Cachier;
        }
        public Cachier(string Wname, int sal) : base(Wname, sal)
        {
            Type = WorkerType.Cachier;
        }
        public Cachier(string Wname, int sal, Branch b) : base(Wname, sal, b)
        {
            Type = WorkerType.Cachier;
        }
    }
}