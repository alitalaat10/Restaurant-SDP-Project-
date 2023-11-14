using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Menu;
using design_pattern.Models.Workers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace design_pattern.Models.Branches
{
    public class Branch
    {
        [Key]
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        // public List<MenuSection> MenuSections { get; set; }
        // public List<Cachier> Cachiers { get; set; }
        // public List<Chef> Chefs { get; set; }
        // public List<Waiter> Waiters { get; set; }
        // public List<Receptionist> Receptionists { get; set; }

    }
}