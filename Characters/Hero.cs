
using System.Configuration.Assemblies;
using Game;

class Hero : Character
{
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Ability> inventory;
    public Hero(string name, double hp, double damage, double experience, int level, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        Experience = experience;
        Level = level;
        inventory = new List<Ability>();
    }
    public double Engage(Undead enemy, Hero playerCharacter)
    {
        return enemy -= playerCharacter.Damage;
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
