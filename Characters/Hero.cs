
using System.Configuration.Assemblies;

class Hero : Character
{
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Ability> inventory;
    public Hero(double experience, int level, string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        Experience = experience;
        Level = level;
        inventory = new List<Ability>();
    }
    public double Engage(Character enemy, Hero playerCharacter)
    {
        return
    }
    public void Dialog()
    {

    }
    public List<Ability> Inventory()
    {
        return inventory;
    }
     public void AddInventory(Ability ability)
    {
        inventory.Add(ability);
    }
    public void RemoveInventory(Ability ability)
    {
        inventory.Remove(ability);
    }
    public void Map()
    {

    }
}
