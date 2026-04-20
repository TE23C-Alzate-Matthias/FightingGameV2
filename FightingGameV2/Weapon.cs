public class Weapon : Item
{
    public int TimesAttack;
    public int MinDmg;
    public int MaxDmg;
    public int MaxDmgMult;
    public int HitChance;
    Random generator = new();

    // method used to make attacks
    public void Attacks(Character attacker, Character target)
    {   
        bool hits = false;
        int dmg = 0;
        // checks how many times the weapon attacks
        for (int i = 0; i < TimesAttack; i++)
        {   
            // method which rolles a number and checks if its a success 
            hits = HitRate(attacker, target);
            // makes it calculate the damage if its a hit
            if (hits == true)
            {  
                dmg += DmgCalculation(attacker, target);  
            }
        }
        // only deals damage and shows text of damage if the hit is a sucess
        if (hits == true)
        {
            Console.WriteLine($"{attacker.Name} dealt {dmg} damage to {target.Name}");
            target.TakeDamage(dmg);
        }
    }
    private int DmgCalculation(Character attacker, Character target)
    {
        int dmg = 0;
        // calcualtes the damage it deals and sets it in dmg
        dmg = generator.Next(MinDmg + attacker.Atk, MaxDmg + (attacker.Atk * MaxDmgMult)) - target.Def;
        // only if the times it attacks is highger than 1 it shows every individual damage number
        if (TimesAttack < 1)
        {
            Console.WriteLine($"{target.Name} took {dmg} damage");
        }
        // return the value of the dmg
        return dmg;
    }
    private bool HitRate(Character attacker, Character target)
    {
        bool hits = false;
        int accuracy;
        // generates a random number between 1 and 100
        accuracy = generator.Next(1, 101);

        // checks if accuarcy is a lower number than Hitchance and if its, gices hits = true
        if (accuracy < HitChance - attacker.Acc + target.Dex)
        {
            Console.WriteLine($"{attacker.Name} missed their attack");
            hits = false;
        }
        else
        {
            hits = true;
        }
        // return the value of hits
        return hits;
    }
}
