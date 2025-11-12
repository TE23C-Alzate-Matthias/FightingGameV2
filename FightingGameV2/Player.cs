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

    private void ChooseName()
    {
        string choice = "";
        string naming = "";

        while (naming != "yes")
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
            naming = choice.ToLower();
        }
    }
}
