using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Tables
{
    public interface IPrototype
    {
        IPrototype getClone();
    }
}