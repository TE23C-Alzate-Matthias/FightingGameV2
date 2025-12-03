// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

public class Player : Character
{
    // not gonna be used for now
    public int StoryPoint;
    private int stat;

    public Player()
    {
        stat = 20;
        hp = 100;
        maxHp = hp;
        ChooseName();
    }

    // when i add things to do in between fights, this will get referenced
    public void WhatToDoFight(Player p, Character e)
    {
        int num = 0;
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
                int.TryParse(choice, out num);
                break;
            }
            // says its invalid option
            else
            {
                Console.WriteLine("Not a valid answer, please try again");
                Console.ReadLine();
            }

        }

        TurnChoice(num, p, e);
    }
    // CURRENTLY REUSING THE CODE FROM AN OLD PROJECT, WILL CHANGE TO MAKE IT LESS SPAGETTHI CODE
    // REMEMBER TO MAKE THIS METHOD LESS REPETETIVE AND BREAK UP INTO SMALLER METHODS
    public void stats()
    {
        int choice = 0;
        string option;
        string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        while (choice != 9)
        {

            Console.Clear();
            Console.WriteLine($"Stat Points Left: {stat}");
            Console.WriteLine("Add statpoints to your character:\n");
            Console.WriteLine($"Player Max Hp: {hp}");

            Console.WriteLine($"1) Vt: {vt}");
            Console.WriteLine($"2) Atk: {atk}");
            Console.WriteLine($"3) Def: {def}");
            Console.WriteLine($"4) Spd: {spd}");
            Console.WriteLine($"5) Acc: {acc}");
            Console.WriteLine($"6) Dex: {dex}");
            Console.WriteLine($"7) Help");
            Console.WriteLine($"8) Reset stat Point");
            Console.WriteLine($"9) Exit");

            option = Console.ReadLine();
            int.TryParse(option, out choice);

            while (!acceptable.Contains(option))
            {
                Console.WriteLine("Unknown option, please try again");
                option = Console.ReadLine();
                int.TryParse(option, out choice);
            }

            if (choice == 7)
            {
                // shows what each stat does
                Console.WriteLine("\nVitality: +10 hp per point");
                Console.WriteLine("Attack: 1+ Minimun and Maximun damage when hitting an attack (+2 maximun damage on heavy attack)");
                Console.WriteLine("Defence: -1 Damage taken when getting hit per point");
                Console.WriteLine("Speed: +5 on Speed Checks per point");
                Console.WriteLine("Accuracy: +1% Chance to hit an attack per point");
                Console.WriteLine("Dexterity: +1% Chance to dodge an attack per point");
                Console.WriteLine("(Click Enter to get back)");
                Console.ReadLine();
            }
            else if (choice == 8)
            {
                Console.WriteLine("Are you sure you want to reset your stats?");
                Console.WriteLine("Write 'yes' if you are sure");
                option = Console.ReadLine();
                if (option == "yes")
                {

                    stat += vt + atk + def + spd + acc + dex;
                    vt = 0;
                    atk = 0;
                    def = 0;
                    spd = 0;
                    acc = 0;
                    dex = 0;
                }
            }
            else if (choice == 9)
            {
                break;
            }
            else if (stat == 0)
            {
                Console.WriteLine("No stat points left, please try again");
                Console.ReadLine();

            }
            // got help with chatGPT to make this more compact
            else if (choice >= 1 && choice <= 6)
            {
                // deduct one stat point and increase the chosen stat
                stat--;
                switch (choice)
                {
                    case 1:
                        vt++;
                        break;
                    case 2:
                        atk++;
                        break;
                    case 3:
                        def++;
                        break;
                    case 4:
                        spd++;
                        break;
                    case 5:
                        acc++;
                        break;
                    case 6:
                        dex++;
                        break;
                }
            }
            hp = 100 + (10 * vt);
            Console.Clear();
        }
        maxHp = hp;

    }

    // method to give the character a name
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