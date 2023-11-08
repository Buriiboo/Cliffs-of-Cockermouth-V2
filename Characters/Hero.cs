
using System.Configuration.Assemblies;
using CharacterBase;
using System.Security.Cryptography.X509Certificates;
using Game;
using MinionCreatorBase;
namespace HeroCreatorBase;

public class Hero : Character
{
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Item> inventory;
    public Hero(string name, double hp, double damage, double experience, int level, int armor, int affinity) 
        : base(name, damage, hp, armor, affinity)
    {
        Experience = experience;
        Level = level;
        inventory = new List<Item>();
    }
    public double Engage(Character enemy, Hero hero)
    {
        return enemy.HP -= hero.Damage;
    }
    public void Dialog()
    {

    }
    
    public List<Item> Inventory()
    {
        return inventory;
    }
    public void AddInventory(Item item)
    {
        inventory.Add(item);
    }
    public void RemoveInventory(Item item)
    {
        inventory.Remove(item);
    }
    public void Map()
    {
    
    }
}