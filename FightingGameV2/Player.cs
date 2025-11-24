// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

public class Player : Character
{
    // not gonna be used for now
    private int stat;
    public Player()
    {
        stat = 20;
        hp = 100;
        maxHp = hp;
        ChooseName();
    }

    // when i add things to do in between fights, this will get referenced
    public static (Player, Enemy) WhatToDoFight(Player p, Enemy e)
    {

        string choice = "";
        // list of options
        List<string> options = ["Light Attack", "Heavy Attack", "Rest"];

        // choose what you want
        while (choice != "1" || choice != "2" || choice != "3")
        {
            Console.WriteLine("Who do you want to do?");
            // writes out list
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {options[i]}");
            }
            // reads choice
            choice = Console.ReadLine();
            // goes out of the while
            if (choice == "1" || choice == "2" || choice == "3")
            {
                break;
            }
            // says its invalid option
            else
            {
                Console.WriteLine("Not a valid answer, please try again");
                Console.ReadLine();
            }
        }

        if (choice == "1")
        {
            p.LightAttack(e);
        }
        else if (choice == "2")
        {
            p.HeavyAttack(e);
        }
        else
        {
            p.Rest(p);
        }

        return (p, e);

    }


    private void ChooseName()
    {
        string choice = "";

        while (choice != "yes")
        {
            name = "";

            // checks if the given text has numbers in it, if it has its on true, if not its on false
            bool ContainsNumbers(string input)
            {
                return Regex.IsMatch(input, @"\d");
            }

            while (name.Length < 3 || name.Length > 15 || ContainsNumbers(name))
            {
                Console.ReadLine();
                Console.Clear();
                // lets you choose your name
                Console.WriteLine("Choose your Characters name (3-14 Characters long, no numbers)");
                name = Console.ReadLine();

                // if the name is shorter than 3 it tells me to try again
                if (name.Length < 3)
                {
                    Console.WriteLine("Name is to short, please try again");

                }
                // same thing but if longer than 15
                else if (name.Length > 15)
                {
                    Console.WriteLine("Namn is to long, please try again");

                }
                // same thing but if it has numbers in it
                else if (ContainsNumbers(name))
                {
                    Console.WriteLine("Name has numbers in it, please try again");

                }
            }

            Console.WriteLine($"Your Characters name is {name}, is this correct? [yes/no]");
            choice = Console.ReadLine();
            choice = choice.ToLower();
        }
    }
}
