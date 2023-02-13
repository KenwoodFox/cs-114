// ProcessLunchOrders SP1
// Alias
using con = System.Console;

namespace ProcessLunchOrders
{

    static void Main(string[] args)
    {
        con.WriteLine("ProcessLunchOrders, SP1");

        // These components included from docx
        Hamburger = 

        con.WriteLine(menuItems.items);
    }

    public class MenuItems
    {
        public MenuItem[] items { get; set; }
    }

    public class MenuItem
    {
        public string name { get; set; }

        public double price { get; set; }

        public string[] addOns { get; set; }

        public double addOnPrice { get; set; }
    }
}
