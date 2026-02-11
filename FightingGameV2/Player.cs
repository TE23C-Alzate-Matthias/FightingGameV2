// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

public class Player : Character
{
    // not gonna be used for now
    public int StoryPoint;
    private int stat;
    // ment to be used
    private Dictionary<int, Action> actions = new();
    public Player()
    {
        stat = 20;
        Hp = 100;
        MaxHp = Hp;
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
    public void Stats()
    {
        int choice = 0;
        int[] acceptable = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        while (choice != 9)
        {
            choice = 0;
            Console.Clear();
            Console.WriteLine($"Stat Points Left: {stat}");
            Console.WriteLine("Add statpoints to your character:\n");
            Console.WriteLine($"Player Max Hp: {Hp}");

            Console.WriteLine($"1) Vt: {Vt}");
            Console.WriteLine($"2) Atk: {Atk}");
            Console.WriteLine($"3) Def: {Def}");
            Console.WriteLine($"4) Spd: {Spd}");
            Console.WriteLine($"5) Acc: {Acc}");
            Console.WriteLine($"6) Dex: {Dex}");
            Console.WriteLine($"7) Help");
            Console.WriteLine($"8) Reset stat Point");
            Console.WriteLine($"9) Exit");

            while (!acceptable.Contains(choice))
            {
                string option = Console.ReadLine();
                int.TryParse(option, out choice);
                if (!acceptable.Contains(choice))
                {
                    Console.WriteLine("Unknown option, please try again");
                }
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
                ResetPoint();
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
               AddPoints(choice);
            }
            Hp = 100 + (10 * Vt);
            Console.Clear();
        }
        MaxHp = Hp;

    }
    private void ResetPoint()
    {   
        Console.Clear();
        string option;
        Console.WriteLine("Are you sure you want to reset your stats?");
                Console.WriteLine("Write 'yes' if you are sure");
                option = Console.ReadLine();
                if (option == "yes")
                {

                    stat += Vt + Atk + Def + Spd + Acc + Dex;
                    Vt = 0;
                    Atk = 0;
                    Def = 0;
                    Spd = 0;
                    Acc = 0;
                    Dex = 0;
                }
                else
                {
                    Console.WriteLine("Reset Cancelled");
                    Console.ReadLine();
                }
    }
    // currently just a placeholder way to add more stats and stuff before using a dictionary to make it easier
    private void AddPoints(int answer)
    {   
        Console.Clear();
        int amount = 0;
        string option;
        Console.WriteLine("How many points do you want to add?");
        Console.WriteLine($"You have {stat} total points left");
        while(amount < stat || amount > stat)
        {
            option = Console.ReadLine();
            int.TryParse(option, out amount);
            if(amount < 0 || amount > stat)
            {
                Console.WriteLine("Not a valid number, please try again");
            }
        }
        stat =- amount;
         switch (answer)
                {
                    case 1:
                        Vt =+ amount;
                        break;
                    case 2:
                        Atk =+ amount;
                        break;
                    case 3:
                        Def =+ amount;
                        break;
                    case 4:
                        Spd =+ amount;
                        break;
                    case 5:
                        Acc =+ amount;
                        break;
                    case 6:
                        Dex =+ amount;
                        break;
                }


    }
    // method to give the character a Name
    private void ChooseName()
    {
        string choice = "";

        while (choice != "yes")
        {
            Name = "";

            // checks if the given text has numbers in it, if it has its on true, if not its on false
            bool ContainsNumbers(string input)
            {
                return Regex.IsMatch(input, @"\d");
            }

            while (Name.Length < 3 || Name.Length > 15 || ContainsNumbers(Name))
            {
                Console.ReadLine();
                Console.Clear();
                // lets you choose your Name
                Console.WriteLine("Choose your Characters Name (3-14 Characters long, no numbers)");
                Name = Console.ReadLine();

                // if the Name is shorter than 3 it tells me to try again
                if (Name.Length < 3)
                {
                    Console.WriteLine("Name is to short, please try again");

                }
                // same thing but if longer than 15
                else if (Name.Length > 15)
                {
                    Console.WriteLine("Namn is to long, please try again");

                }
                // same thing but if it has numbers in it
                else if (ContainsNumbers(Name))
                {
                    Console.WriteLine("Name has numbers in it, please try again");

                }
            }

            Console.WriteLine($"Your Characters Name is {Name}, is this correct? [yes/no]");
            choice = Console.ReadLine();
            choice = choice.ToLower();
        }
    }
}