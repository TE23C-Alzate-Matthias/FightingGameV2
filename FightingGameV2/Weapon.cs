public class Weapon : Item
{
    public int TimesAttack;
    public int MinDmg;
    public int MaxDmg;
    public int MaxDmgMult;
    public int HitChance;
    Random generator = new();

    // all bellow is ment to move move attacking logic to the weapon but currently do nothing
    public void Attacks(Character attacker, Character target)
    {   
        bool hits = false;
        int dmg = 0;
        for (int i = 0; i < TimesAttack; i++)
        {   
            hits = HitRate(attacker, target);
            if (hits == true)
            {  
                dmg = DmgCalculation(attacker, target);  
            }
        }
        if (hits == true)
        {
            Console.WriteLine($"{attacker.Name} dealt {dmg} damage to {target.Name}");
            target.TakeDamage(dmg);
        }
    }
    private int DmgCalculation(Character attacker, Character target)
    {
        int dmg = 0;
        int totaldmg = 0;
        dmg = generator.Next(MinDmg + attacker.Atk, MaxDmg + (attacker.Atk * MaxDmgMult)) - target.Def;
        if (TimesAttack < 1)
        {
            Console.WriteLine($"{target.Name} took {dmg} damage");
        }
        totaldmg += dmg;

        return totaldmg;
    }
    private bool HitRate(Character attacker, Character target)
    {
        bool hits = false;
        int accuracy;
        accuracy = generator.Next(1, 101);

        if (accuracy < HitChance - attacker.Acc + target.Dex)
        {
            Console.WriteLine($"{attacker.Name} missed their attack");
            hits = false;
        }
        else
        {
            hits = true;
        }
        return hits;
    }
}
