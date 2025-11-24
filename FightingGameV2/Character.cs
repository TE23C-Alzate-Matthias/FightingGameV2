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
    protected int hp { get; set; }
    protected int vt;
    protected int atk;
    protected int def;
    protected int spd;
    protected int acc;
    protected int dex;

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

            (p, e) = Player.WhatToDoFight(p, e);
            (p, e) = Enemy.AttackLogic(p, e);

            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
            p.hp = Math.Max(0, p.hp);
            e.hp = Math.Max(0, e.hp);
        }

        WinCheck(p, e);
        p.hp = p.maxHp;
        e.hp = e.maxHp;
        Console.WriteLine("Click anything to continue");
        Console.ReadLine();

        return (p, e);
    }

    private void TakeDamage(int amount)
    {
        hp -= amount;
    }

    private void Heal(int amount)
    {
        hp += amount;
    }
    protected virtual void LightAttack(Character target)
    {   
        Random generator = new();
        int dmg;

        dmg = generator.Next(10, 21);
        Console.WriteLine($"{target.name} took {dmg} damage");


        target.TakeDamage(dmg);
    }

    protected virtual void HeavyAttack(Character target)
    {
        
        Random generator = new();
        int dmg;

        dmg = generator.Next(20, 41);
        Console.WriteLine($"{target.name} took {dmg} damage");

        target.TakeDamage(dmg);

    }

    protected void Rest(Character self)
    {
        Random generator = new();
        
        int heal;

        heal = generator.Next(maxHp/7, (maxHp/5)+1);
        Console.WriteLine($"{self.name} healed {heal} damage");

        self.Heal(heal);
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
