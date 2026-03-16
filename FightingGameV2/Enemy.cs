public class Enemy : Character, IAttacking, IHealable, IAttackable
{
    public Enemy()
    {
        Hp = 100 + 10*Vt;
        MaxHp = Hp;
    }
    public void AttackChoice(Player p, Enemy e)
    {
        int choice;

        // currently just randomly generates a number between 1 and 3 to choose there action
        // will get better logic to make the enemy "smarter" later
        choice = generator.Next(1, 4);

        TurnChoice(choice, e, p);
    }
    public void SetMaxHp()
    {
        MaxHp = Hp;
    }
    public void HealDamage(int heal)
    {
        Hp += heal;
        // makes sure the healing does not go above the MaxHp
        Hp = Math.Min(Hp, MaxHp);
    }

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        // makes sure the damage does not make the Hp go bellow 0
        Hp = Math.Max(Hp, 0);
    }
}
