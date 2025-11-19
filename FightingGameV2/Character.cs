using System.Diagnostics;

public class Character
{
    // ==================== CLASS ====================

    // Hp - hitpoint
    // Vt - Vitality
    // Atk - Attack
    // Def - Defense
    // Spd - Speed
    // Acc - Accuracy
    // Dex - Dexterity

    public string name;
    protected int maxHp;
    public int hp;
    protected int vt;
    protected int atk;
    protected int def;
    protected int spd;
    protected int acc;
    protected int dex;
    protected int dmg;

    // very simple how the turn ordering will work for now, gonna be changed to have more options
    public static (Player, Enemy) TurnOrder(Player p, Enemy e)
    {

        Random generator = new();
        int round = 0;

        while (p.hp > 0 && e.hp > 0)
        {
            round++;
            Console.Clear();
            Console.WriteLine($"======= ROUND {round} =======");
            Console.WriteLine($"{p.name} Hp: {p.hp} || {e.name} HP: {e.hp}");

            p.dmg = generator.Next(10, 21);
            e.hp -= p.dmg;
            Console.WriteLine($"{p.name} did {p.dmg} damage");
            e.dmg = generator.Next(10, 21);
            p.hp -= e.dmg;
            Console.WriteLine($"{e.name} did {e.dmg} damage");
            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
            p.hp = Math.Max(0, p.hp);
            e.hp = Math.Max(0, e.hp);
        }

        WinCheck(p, e);
        p.hp = p.maxHp;
        e.hp = e.maxHp;

        return (p, e);
    }

    protected static (Player, Enemy) LightAttack(Player p, Enemy e)
    {
        Console.WriteLine("Light Attack Type Shit");

        return (p, e);
    }

    protected static (Player, Enemy) HeavyAttack(Player p, Enemy e)
    {
        Console.WriteLine("Light Attack Type Shit");

        return (p, e);
    }

    protected static (Player, Enemy) Rest(Player p, Enemy e)
    {


        return (p, e);
    }

    private static void WinCheck(Player p, Enemy e)
    {
        if (p.hp == 0)
        {
            Console.WriteLine("You won!");
        }
        else if (e.hp == 0)
        {
            Console.WriteLine("You lost!");
        }
        else
        {
            Console.WriteLine("Its a draw!");
        }
        
    }


}
