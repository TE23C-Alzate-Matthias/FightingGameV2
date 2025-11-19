public class Enemy : Character
{
    int choice;
    public Enemy()
    {
        hp = 100;
        maxHp = hp;
    }

    // not gonna be used for now
    // not sure if its gonna be public or private
    public static (Player, Enemy) AttackLogic(Player p, Enemy e)
    {
        Random generator = new();

        e.choice = generator.Next(1, 4);

        return(p, e);
    }
}
