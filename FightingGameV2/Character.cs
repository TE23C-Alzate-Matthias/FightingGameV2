using System.Text.Json.Serialization;
using FightingGameV2;
public abstract class Character
{
    // ==================== CLASS ====================

    // Hp - hitpoint
    // Vt - Vitality
    // Atk - Attack
    // Def - Defense
    // Spd - Speed
    // Acc - Accuracy
    // Dex - Dexterity

    public string Name { get; set; }
    // everything is able to see all this variables but just not able to change them.
    // [JsonInculde] makes that when i read from the Json, its able to change the stats of the characters that are needed to be changed
    [JsonInclude]
    public int MaxHp { get; protected set; }
    [JsonInclude]
    public int Hp { get; protected set; }
    [JsonInclude]
    public int Vt { get; protected set; }
    [JsonInclude]
    public int Atk { get; protected set; }
    [JsonInclude]
    public int Def { get; protected set; }
    [JsonInclude]
    public int Spd { get; protected set; }
    [JsonInclude]
    public int Acc { get; protected set; }
    [JsonInclude]
    public int Dex { get; protected set; }


    protected Random generator = new();

    // very simple how the turn ordering will work for now, gonna be changed to have more options
    public void TurnOrder(Player p, Enemy e)
    {
        int round = 0;
        e.Hp = e.Vt * 10 + 100;
        e.MaxHp = e.Hp;
        
        while (p.Hp > 0 && e.Hp > 0)
        {
            round++;
            Console.Clear();
            Console.WriteLine(e.Vt);
            Console.WriteLine($"======= ROUND {round} =======");
            Console.WriteLine($"{p.Name} Hp: {p.Hp} || {e.Name} Hp: {e.Hp}");

            if (p.Hp > 0)
            {
                p.WhatToDoFight(p, e);
            }
            if (e.Hp > 0)
            {
                e.AttackLogic(p, e);
            }

            Console.WriteLine("Click anything to continue");
            Console.ReadLine();
        }

        Fight.WinCheck(p, e);
        p.Heal(MaxHp);
        e.Heal(MaxHp);
        Console.WriteLine("Click anything to continue");
        Console.ReadLine();
    }
    // makes a character take damage
    private void TakeDamage(int amount)
    {   
        Hp -= amount;
        // makes sure the damage does not make the Hp go bellow 0
        Hp = Math.Max(Hp, 0);
    }
    // makes a character heal
    private void Heal(int amount)
    {
        Hp += amount;
        // makes sure the healing does not go above the MaxHp
        Hp = Math.Min(Hp, MaxHp);
    }
    // light attack method both players can use
    private void LightAttack(Character target, Character attacker)
    {
        int dmg;

        dmg = generator.Next(10 + attacker.Atk, 21 + attacker.Atk);
        Console.WriteLine($"{target.Name} took {dmg} damage");
        target.TakeDamage(dmg);

    }
    // heavy attack method both players can use
    private void HeavyAttack(Character target, Character attacker)
    {
        int dmg;

        dmg = generator.Next(20 + attacker.Atk, 41 + attacker.Atk);
        Console.WriteLine($"{target.Name} took {dmg} damage");

        target.TakeDamage(dmg);

    }
    private void Rest(Character self)
    {   
        int heal;

        // looks at the characters MaxHp and makes you heal somewhere between a 7th and a 5th of the Hp
        heal = generator.Next(MaxHp/10, (MaxHp/7)+1);
        Console.WriteLine($"{self.Name} healed {heal} damage");

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
}
