using System.ComponentModel.DataAnnotations;
using design_pattern.Models.Branches;
using Microsoft.EntityFrameworkCore;

namespace design_pattern.Models.Menu
{
    public class MenuSection : MenuCmp
    {
        public List<MenuCmp> Items { get; set; } = new List<MenuCmp>();
        public string BranchName { get; set; }
        public Branch Branch { get; set; }
        public static readonly bool isContainer = true;
        public MenuSection(string name, string desc) : base(name, desc)
        {
        }

        public override void Add(MenuCmp cmp)
        {
            Items.Add(cmp);
        }
        public override void Remove(MenuCmp cmp)
        {
            Items.Remove(cmp);
        }
        public override MenuCmp GetChild(int idx)
        {
            return Items[idx];
        }
        public override MenuCmp getItem(int idx)
        {
            return Items[idx];
        }
        public override void setItem(int idx, MenuCmp cmp)
        {
            if (Items[idx] != null)
            {
                Items[idx] = cmp;
            }
        }
        public override void Print()
        {
            Console.WriteLine($"Section {this.Name} {this.Desc}");
            foreach (var item in Items)
            {
                item.Print();
            }
        }
    }
}