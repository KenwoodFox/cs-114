// CookieClass
// Alias
using System;
using System.Collections.Generic;

using con = System.Console;

class CookieClass
{
    static void Main(string[] args)
    {
        con.WriteLine(@"
  ____            _    _         ____ _               
 / ___|___   ___ | | _(_) ___   / ___| | __ _ ___ ___ 
| |   / _ \ / _ \| |/ / |/ _ \ | |   | |/ _` / __/ __|
| |__| (_) | (_) |   <| |  __/ | |___| | (_| \__ \__ \
 \____\___/ \___/|_|\_\_|\___|  \____|_|\__,_|___/___/

Free cookies for all!

");

        // Prepare a blank order
        Order userOrder = new Order();
        con.WriteLine("Welcome to CookieClass, please have a look at our menu and make a selection.\nEnter any non-order number to continue.");

        userOrder.showMenu();
        
        while (true){
            con.Write("Please enter a selection (or -1 to stop): ");
            int _sel = int.Parse(con.ReadLine());
            if (_sel == -1 ){break;} // Catch bad input early

            con.Write("Please enter a qty for this item: ");
            int _qty = int.Parse(con.ReadLine());

            // Add the order
            try
            {
                userOrder.AddItem(_sel, _qty);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                break;
            }
        }

        // Print order total
        userOrder.showTotal();

        con.WriteLine("\nThank you for coming to our shop!");
    }
}

struct Item: IEquatable<Item>
{
    // Name of this item
    public string itemName { get; set; }

    // Cost per single item
    public double dPrice { get; set; }

    public override string ToString()
    {
        return $"{itemName}\t{dPrice:C}";
    }

    public bool Equals(Item other)
    {
        if (other.itemName == null) return false;
        return (this.itemName.Equals(other.itemName));
    }
}

struct OrderItem: IEquatable<OrderItem>
{
    // An item
    public Item item { get; set; }
    // Items in this line
    public int nItems{ get; set; }

    public bool Equals(OrderItem other)
    {
        // if (other.item == null) return false;
        return (this.item.Equals(other.item));
    }
}


class Order
{
    // Private memory
    // All the possible items
    private List<Item> menuItems = new List<Item>();

    // All the items in this order
    private List<OrderItem> orderItems = new List<OrderItem>();

    public Order(){
        // Add all menu items
        menuItems.Add(new Item() {itemName="Oreo Cookie\t", dPrice=1.29});
        menuItems.Add(new Item() {itemName="Sugar Cookie\t", dPrice=1.49});
        menuItems.Add(new Item() {itemName="Chocolate Chip Cookie", dPrice=1.79});
    }

    public void showMenu(){
        for (int i = 0; i < menuItems.Count; i++)
        {
            con.WriteLine($"Item {i}\t{menuItems[i]}");
        }
    }

    public void AddItem(int sel, int qty){
        orderItems.Add(new OrderItem() {item=menuItems[sel], nItems=qty});
    }

    public void showTotal(){
        double tot = 0.0;
        for (int i = 0; i < orderItems.Count; i++)
        {
            double _sum = orderItems[i].nItems * orderItems[i].item.dPrice;
            con.WriteLine($"{orderItems[i].nItems}\t{orderItems[i].item.itemName}\t{_sum:C}");
            tot += _sum;
        }

        con.WriteLine($"Your total is: {tot:C}");
    }
}
