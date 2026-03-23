public class Weapon : Item
{
    public int TimesAttack;
    public int MinDmg;
    public int MaxDmg;
    public int MinDmgMult;
    public int MaxDmgMult;
    public int HitChance;
    Random generator;
    public void Attacks(Character attacker, Character target)
    {   
        bool hits;
        int dmg = 0;
        for (int i = 0; i < TimesAttack; i++)
        {   
            hits = HitRate(attacker, target, HitChance);
            if (hits = true)
            {  
                dmg = DmgCalculation(attacker, target);  
            }
        }
        Console.WriteLine($"{target.Name} took a total of {dmg} damage");
        target.TakeDamage(dmg);
    }
    private int DmgCalculation(Character attacker, Character target)
    {
        int dmg = 0;
        int totaldmg = 0;
        dmg = generator.Next(MinDmg + (attacker.Atk * MinDmgMult), MaxDmg + (attacker.Atk * MaxDmgMult)) - target.Def;
        if (TimesAttack < 1)
        {
            Console.WriteLine($"{target.Name} took {dmg} damage");
        }
        totaldmg += dmg;

        return totaldmg;
    }
    private bool HitRate(Character attacker, Character target, int chance)
    {
        bool hits = false;
        int accuracy;
        accuracy = generator.Next(1, 101);

        if (accuracy < chance - attacker.Acc + target.Dex)
        {
            Console.WriteLine($"{attacker.Name} missed their attack\n");
            hits = false;
        }
        else
        {
            hits = true;
        }
        return hits;
    }
}
