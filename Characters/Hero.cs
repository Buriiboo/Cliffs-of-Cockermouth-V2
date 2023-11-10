
using System.Configuration.Assemblies;
using CharacterBase;
using System.Security.Cryptography.X509Certificates;
using Game;
using MinionCreatorBase;
using System.Security;
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
    public void ShowInventory()
    {
        for(int i = 0; i < inventory.Count; i++){
            Console.WriteLine($"{i + 1}: {inventory[i]}");
        }
    }
    public void HandelInventory(Hero player, Character other)
    {
        if(player.Inventory().Count == 0){
            Console.WriteLine("Your inventory is empty!");
            return;
        }
        player.ShowInventory();
        int ItemChoice = int.Parse(Console.ReadLine());
        Item item = player.Inventory()[ItemChoice - 1];
        if(item is ThrowWeapons throwWeapons)
            player.ItemAttack(other, player, throwWeapons);
        
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