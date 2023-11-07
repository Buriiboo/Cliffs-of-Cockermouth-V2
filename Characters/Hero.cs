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