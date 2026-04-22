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
        
    }
    // very simple how the turn ordering will work for now, gonna be changed to have more options
    public static void TurnOrder(Player p, Enemy e)
    {   
        int round = 0;
        
        // keeps playing until one of the Hp are bellow 0
        while (p.Hp > 0 && e.Hp > 0)
        {
            round++;
            Console.Clear();
            Console.WriteLine($"======= ROUND {round} =======");
            Console.WriteLine($"{p.Name} Hp: {p.Hp} || {e.Name} Hp: {e.Hp}");

            // as long their hp is above 0, they can make an action, made this way so its harder for a draw
            if (p.Hp > 0)
            {
                p.AttackChoice(p, e);
            }
            if (e.Hp > 0)
            {
                e.AttackChoice(p, e);
            }

            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
        }

        WinCheck(p, e);
        p.HealDamage(p.MaxHp);
        e.HealDamage(e.MaxHp);
        p.PotionUsesGive();
        Console.WriteLine("Click anything to continue");
        Console.ReadLine();
    }

    
}
