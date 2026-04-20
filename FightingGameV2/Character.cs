using System.Text.Json.Serialization;
public abstract class Character : IAttackable, IHealable
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
    public Weapon lightSword = new() {TimesAttack = 1, MinDmg = 10, MaxDmg = 21, HitChance = 60, MaxDmgMult = 1};
    public Weapon heavySword = new() {TimesAttack = 1, MinDmg = 20, MaxDmg = 41, HitChance = 30, MaxDmgMult = 2};

    protected static Random generator = new();

    private void Rest(Character self)
    {   
        int heal;

        // looks at the characters MaxHp and makes you heal somewhere between a 7th and a 5th of the Hp
        heal = generator.Next(MaxHp/10, (MaxHp/7)+1);
        Console.WriteLine($"{self.Name} healed {heal} damage");

        self.HealDamage(heal);
    }
    // method for both player and enemy which uses to know what they want to do
    protected void TurnChoice(int choice, Character self, Character target)
    {   
        if (choice == 1)
        {   
            lightSword.Attacks(self, target);
        }
        else if (choice == 2)
        {   
            heavySword.Attacks(self, target);
        }
        else
        {
            self.Rest(self);
        }
    }
    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        // makes sure the damage does not make the Hp go bellow 0
        Hp = Math.Max(Hp, 0);
    }
    public void HealDamage(int heal)
    {
        Hp += heal;
        // makes sure the healing does not go above the MaxHp
        Hp = Math.Min(Hp, MaxHp);
    }
}
