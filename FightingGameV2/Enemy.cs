public class Enemy : Character
{
    int choice;
    public Enemy()
    {
        hp = 100;
        maxHp = hp;
    }

    public void AttackLogic(Player p, Enemy e)
    {
        Random generator = new();

        e.choice = generator.Next(1, 4);

        if (e.choice == 1)
        {
            e.LightAttack(p, e);
        }
        else if (e.choice == 2)
        {
            e.HeavyAttack(p, e);
        }
        else
        {
            e.Rest(e);
        }
    }
}
