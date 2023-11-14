
namespace design_pattern.Models.Menu
{
    public class MenuItem : MenuCmp
    {
        public static readonly bool isContainer = false;

        public MenuItem():base()
        {
        }
        public MenuItem(string name, string desc, double price) : base(name, desc)
        {
            this.Price = price;
        }

        public override void Print()
        {
            Console.WriteLine($"Item {this.Name} {this.Desc}");
        }
    }
}