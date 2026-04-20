using FightingGameV2;

public class Menu : IMenuOption
{    
    // the Intermission menu when you are between fights
    public static void Intermission(Player p, Enemy e)
    {   
        Menu menu = new();
        int choice = 0;
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
        actions.Add(3, p.backpack.Display);
        // goes to the fight
        actions.Add(4, () =>
        {
            Fight.TurnOrder(p, e);
        });
        // exits the program
        actions.Add(5, () =>
        {
            ExitGame();
        });



        Console.Clear();
        // as long the choice isnt actions.count - 1 it will stay in the looå
        while (choice != actions.Count - 1)
        {   
            Console.Clear();
            choice = 0;
            menu.MenuOption();

            while (choice < 1 || choice > actions.Count)
            {   
                option = Console.ReadLine();
                int.TryParse(option, out choice);
                if (choice < 1 || choice > actions.Count)
                {
                    Console.WriteLine("Unknown option, please try again");
                }
            }
            actions[choice]();
        }
    }

    public void MenuOption()
    {
        List<string> options = ["Check Stats", "Next Enemy","Inventory", "Start Next Fight", "Quit"];
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {options[i]}");
        }
    }

    private static void ExitGame()
    {
        string option;
        // if you want to exit program
        Console.WriteLine("Are you sure you want to quit? (Write yes if you want to quit)");
        option = Console.ReadLine();
        if (option.ToLower() == "yes")
        {
            // exits the program and closes it
            Environment.Exit(0);
        }
    }

}
