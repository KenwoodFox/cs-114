// ProcessLunchOrders SP1
using Newtonsoft.Json;

// Alias
using con = System.Console;

namespace ProcessLunchOrders
{

    static void Main(string[] args)
    {
        con.WriteLine("ProcessLunchOrders, SP1");

        string fileName = "menu.json";
        string jsonString = File.ReadAllText(fileName);
        MenuItems menuItems =
            JsonSerializer.Deserialize<Menuitems>(jsonString);

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
