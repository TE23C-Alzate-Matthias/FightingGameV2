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
    protected float maxHp;
    public float hp;
    protected int vt;
    protected int atk;
    protected int def;
    protected int spd;
    protected int acc;
    protected int dex;
    protected float dmg;

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
            e.hp =- p.dmg;
            Console.WriteLine($"{p.name} did {p.dmg} damage");
            e.dmg = generator.Next(10, 21);
            p.hp =- e.dmg;
            Console.WriteLine($"{e.name} did {e.dmg} damage");
            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
        }

        return (p, e);
    }

    private static (Player, Enemy) Attacking(Player p, Enemy e)
    {


        return (p, e);
    }

    private static (Player, Enemy) WinCheck(Player p, Enemy e)
    {
        

        return (p, e);
    }


}
