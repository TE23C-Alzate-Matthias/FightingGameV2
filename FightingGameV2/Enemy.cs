public class Enemy : Character
{
    public void AttackLogic(Player p, Enemy e)
    {   
        int choice;

        // currently just randomly generates a number between 1 and 3 to choose there action
        // will get better logic to make the enemy "smarter" later
        choice = generator.Next(1, 4);

        TurnChoice(choice, e, p);
    }

    public void GiveStats(string naming, int vtP, int atkP, int defP, int spdP, int accP, int dexP)
    {   
        name = naming;
        vt = vtP;
        atk = atkP;
        def = defP;
        spd = spdP;
        acc = accP;
        dex = dexP;
        hp = 100 + vt * 10;
        maxHp = hp;

    }
}
