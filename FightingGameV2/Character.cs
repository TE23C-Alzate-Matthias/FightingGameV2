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

    protected Random generator = new();

    // very simple how the turn ordering will work for now, gonna be changed to have more options
    public void TurnOrder(Player p, Enemy e)
    {
        int round = 0;

        while (p.hp > 0 && e.hp > 0)
        {
            round++;
            Console.Clear();
            Console.WriteLine($"======= ROUND {round} =======");
            Console.WriteLine($"{p.name} Hp: {p.hp} || {e.name} HP: {e.hp}");

            if (p.hp > 0)
            {
                p.WhatToDoFight(p, e);
            }
            if (e.hp > 0)
            {
                e.AttackLogic(p, e);
            }

            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
        }

        WinCheck(p, e);
        p.Heal(maxHp);
        e.Heal(maxHp);
        Console.WriteLine("Click anything to continue");
        Console.ReadLine();
    }
    // makes a character take damage
    private void TakeDamage(int amount)
    {   
        hp -= amount;
        // makes sure the damage does not make the hp go bellow 0
        hp = Math.Max(hp, 0);
    }
    // makes a character heal
    private void Heal(int amount)
    {
        hp += amount;
        // makes sure the healing does not go above the maxHp
        hp = Math.Min(hp, maxHp);
    }
    private void LightAttack(Character target, Character attacker)
    {
        int dmg;

        dmg = generator.Next(10, 21);
        Console.WriteLine($"{target.name} took {dmg} damage");
        target.TakeDamage(dmg);

    }
    private void HeavyAttack(Character target, Character attacker)
    {
        int dmg;

        dmg = generator.Next(20, 41);
        Console.WriteLine($"{target.name} took {dmg} damage");

        target.TakeDamage(dmg);

    }
    private void Rest(Character self)
    {   
        int heal;

        // looks at the characters maxHp and makes you heal somewhere between a 7th and a 5th of the hp
        heal = generator.Next(maxHp/7, (maxHp/5)+1);
        Console.WriteLine($"{self.name} healed {heal} damage");

        self.Heal(heal);
    }
    // method for both player and enemy which uses to know what they want to do
    protected void TurnChoice(int choice, Character self, Character target)
    {   
        if (choice == 1)
        {
            self.LightAttack(target, self);
        }
        else if (choice == 2)
        {
            self.HeavyAttack(target, self);
        }
        else
        {
            self.Rest(self);
        }
    }
    // checks who
    private void WinCheck(Player p, Character e)
    {
        if (e.hp == 0)
        {
            Console.WriteLine("You won!");
            p.StoryPoint++;
        }
        else if (p.hp == 0)
        {
            Console.WriteLine("You lost!");
            p.StoryPoint = 4;
        }
        else
        {
            Console.WriteLine("Its a draw!");
        }
        
    }


}
