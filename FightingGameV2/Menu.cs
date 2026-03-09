public class Menu
{

    public static void Intermission(Player p, Enemy e)
    {
        int choice = -1;
        string option;
        Dictionary<int, Action> actions = new();
        // goes back to the stats menu
        actions.Add(1, p.Stats);
        // checks the stats of the next enemy
        actions.Add(2, () =>
        {
            Console.Clear();
            Console.WriteLine($"Next enemy: {e.Name}");
            Console.WriteLine($"Hp: {e.Hp}");
            Console.WriteLine($"Vitality: {e.Vt}");
            Console.WriteLine($"Attack: {e.Atk}");
            Console.WriteLine($"Defence: {e.Def}");
            Console.WriteLine($"Speed: {e.Spd}");
            Console.WriteLine($"Accuracy: {e.Acc}");
            Console.WriteLine($"Dexterity: {e.Dex}");
            Console.WriteLine($"Press enter to get back");
            Console.ReadLine();
        });
        // goes to the fight
        actions.Add(3, () =>
        {
            p.TurnOrder(p, e);
        });
        // exits the program
        actions.Add(4, () =>
        {
            // if you want to exit program
            Console.WriteLine("Are you sure you want to quit? (Write yes if you want to quit)");
            option = Console.ReadLine();
            if (option.ToLower() == "yes")
            {
                // exits the program and closes it
                Environment.Exit(0);
            }
        });

        while (choice != 3)
        {   
            choice = -1;
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.Write("\n1) Check Stats ");
            if (p.stat != 0)
            {
                Console.Write($"(YOU HAVE {p.stat} STAT POINTS TO USE)");
            }
            Console.WriteLine("\n2) Next Enemy");
            Console.WriteLine("3) Start Next Fight");
            Console.WriteLine("4) Quit");

            while (choice < 0 || choice > 4)
            {
                option = Console.ReadLine();
                int.TryParse(option, out choice);
                if (choice < 0 || choice > 4)
                {
                    Console.WriteLine("Unknown option, please try again");
                }
            }
            actions[choice]();
        }

    }
}
