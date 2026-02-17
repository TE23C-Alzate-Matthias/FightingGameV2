// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;
public class Player_Naming
{
    // method to give the character a Name
    public void ChooseName(Player p)
    {
        string choice = "";

        while (choice != "yes")
        {
            p.Name = "";

            // checks if the given text has numbers in it, if it has its on true, if not its on false
            bool ContainsNumbers(string input)
            {
                return Regex.IsMatch(input, @"\d");
            }

            while (p.Name.Length < 3 || p.Name.Length > 15 || ContainsNumbers(p.Name))
            {
                Console.ReadLine();
                Console.Clear();
                // lets you choose your Name
                Console.WriteLine("Choose your Characters Name (3-14 Characters long, no numbers)");
                p.Name = Console.ReadLine();

                // if the Name is shorter than 3 it tells me to try again
                if (p.Name.Length < 3)
                {
                    Console.WriteLine("Name is to short, please try again");

                }
                // same thing but if longer than 15
                else if (p.Name.Length > 15)
                {
                    Console.WriteLine("Namn is to long, please try again");

                }
                // same thing but if it has numbers in it
                else if (ContainsNumbers(p.Name))
                {
                    Console.WriteLine("Name has numbers in it, please try again");

                }
            }

            Console.WriteLine($"Your Characters Name is {p.Name}, is this correct? [yes/no]");
            choice = Console.ReadLine();
            choice = choice.ToLower();
        }
    }
}
