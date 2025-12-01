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

        choice = generator.Next(1, 4);

        TurnChoice(choice, e, p);
    }
}
