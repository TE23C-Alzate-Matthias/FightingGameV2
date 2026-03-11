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
}
