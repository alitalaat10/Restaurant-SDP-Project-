using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Models.Menu
{
    public abstract class MenuCmp
    {

        public int Id { get; set; }
        public virtual double Price { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        [ForeignKey("MenuSectionId")]
        public int MenuSectionId { get; set; }
        public MenuSection MenuSection { get; set; }
        public MenuCmp()
        {
        }
        public MenuCmp(string name, string desc)
        {
            this.Name = name;
            this.Desc = desc;
        }
        public virtual void Add(MenuCmp cmp)
        {
            throw new Exception("Not Implemented");
        }
        public virtual void Remove(MenuCmp cmp)
        {
            throw new Exception("Not Implemented");
        }
        public virtual MenuCmp GetChild(int idx)
        {
            throw new Exception("Not Implemented");
        }
        public virtual MenuCmp getItem(int idx)
        {
            throw new Exception("Not Implemented");
        }
        public virtual void setItem(int idx, MenuCmp cmp)
        {
            throw new Exception("Not Implemented");
        }
        public virtual void Print()
        {
            throw new Exception("Not Implemented");
        }

    }
}