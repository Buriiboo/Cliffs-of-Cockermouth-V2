abstract class Character
{
    public double Damage {get; set;}
    public double HP {get; set;}
    public int Armor {get; set;}
    public int Affinity {get; set;}
    public List<Abilities> abilityList;
    public Character(double damage, double hp, int armor, int affinity)
    {
        Damage = damage;
        HP = hp;
        Armor = armor;
        Affinity = affinity;
        abilityList = new List<Abilities>();
    }
}





