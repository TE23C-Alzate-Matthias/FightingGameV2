using System;

namespace FightingGameV2;

public class Fight
{
    // checks who wins
    public static void WinCheck(Player p, Character e)
    {   
        // if enemy Hp is 0, you win
        if (e.Hp == 0)
        {
            Console.WriteLine("You won!");
            p.StoryPoint++;
        }
        // if player Hp is 0, you lose
        else if (p.Hp == 0)
        {
            Console.WriteLine("You lost!");
            p.StoryPoint = 4;
        }
        // if both Hp is 0, its a draw
        else
        {
            Console.WriteLine("Its a draw!");
        }
        
    }

}
