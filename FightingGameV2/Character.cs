public class Character
{
        // ==================== CLASS ====================

    // Hp - hitpoint
    // Vt - Vitality
    // Atk - Attack
    // Def - Defense
    // Spd - Speed
    // Acc - Accuracy
    // Dex - Dexterity

    public string name;
    protected float hp;
    protected float maxHp;
    protected int vt;
    protected int atk;
    protected int def;
    protected int spd;
    protected int acc;
    protected int dex;

    public static (Player, Enemy) Attacking(Player p, Enemy e)
    {
        return (p, e);
    }
}
