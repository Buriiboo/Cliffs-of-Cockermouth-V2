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

class Hero : Character
{
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Inventory> inventory;
    public Hero(double experience, int level, double damage, double hp, int armor, int affinity) : base(damage, hp, armor, affinity)
    {
        Experience = experience;
        Level = level;
    }
    public void Engage()
    {

    }
    public void Dialog()
    {

    }
    public void InventoryManagement()
    {

    }
    public void Map()
    {

    }
}

class Minion : Character
{
    public Minion(double damage, double hp, int armor, int affinity) : base(damage, hp, armor, affinity)
    {

    }
    public void Engage()
    {

    }
}

class Friendly : Character
{
    public Friendly(double damage, double hp, int armor, int affinity) : base(damage, hp, armor, affinity)
    {

    }
    public void Dialog()
    {

    }
}