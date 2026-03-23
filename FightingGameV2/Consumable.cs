public class Consumable : Item
{   
    int maxUses;
    public int currentUses {get; private set;}
    public Consumable()
    {
        maxUses = 10;
        currentUses = maxUses;
    }
    public void Use(Character target)
    {
        if (currentUses > 0)
        {
            int total = 0;
            total += Random.Shared.Next(10, 26);
            target.HealDamage(total);
            Console.WriteLine($"Your hp is now {target.Hp}");
            currentUses--;
            Console.WriteLine($"You have {currentUses} left");
        }
        else
        {
            Console.WriteLine("You have no more uses for your potion");
        }
    }
}
