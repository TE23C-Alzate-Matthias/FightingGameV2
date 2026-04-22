public class Consumable : Item
{   
    public int maxUses {get; private set;}
    public int currentUses {get; private set;}
    public Consumable()
    {
        maxUses = 3;
        currentUses = maxUses;
    }
    public void Use(Character self)
    {
        if (currentUses > 0)
        {
            int total = 0;
            total += Random.Shared.Next(self.Hp/7, self.Hp/5);
            self.HealDamage(total);
            Console.WriteLine($"{self.Name} healed {total}");
            Console.WriteLine($"{self.Name} hp is now {self.Hp}");
            currentUses--;
            Console.WriteLine($"{self.Name} has {currentUses} uses left");
        }
        else
        {
            Console.WriteLine($"{self.Name} has no more uses for their potion");
        }
    }
    public void ResetUses()
    {
        currentUses = maxUses;
    }
}
