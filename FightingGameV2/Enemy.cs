public class Enemy : Character, IAttacking
{
    public void AttackChoice(Player p, Enemy e)
    {
        int choice;

        // currently just randomly generates a number between 1 and 3 to choose there action
        // will get better logic to make the enemy "smarter" later
        choice = generator.Next(1, 4);

        TurnChoice(choice, e, p);
    }
    // as i currently dont know how to fix the hp of the enemy when getting from the json, this is a bandaid fix
    public void FixHp()
    {
        SetMaxHp();
        HealDamage(MaxHp);
    }
    private void SetMaxHp()
    {
        MaxHp = Hp + 10 * Vt;
    }
}
