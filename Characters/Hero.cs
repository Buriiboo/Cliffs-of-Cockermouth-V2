
class Hero : Character
{
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Inventory> inventory;
    public Hero(double experience, int level, string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        Experience = experience;
        Level = level;
    }
    public double Engage(Character enemy, Hero playerCharacter)
    {
        return 
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
