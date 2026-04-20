public class Inventory
{   
    // makes a list of Items
    public List<Item> Items = [];
    // when it gets called it shows all items you have in your inventory
    public void Display()
    {   
        Console.Clear();
        Console.WriteLine("Items you have:");
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i+1}) {Items[i].Name}");
        }
        Console.WriteLine("Press anything to go back");
        Console.ReadLine();
    }
}
