
using System.Configuration.Assemblies;
using CharacterBase;
using System.Security.Cryptography.X509Certificates;
using Game;
using MinionCreatorBase;
using System.Security;
namespace HeroCreatorBase;
public class Hero
{
    public string Name {get; set;}
    public double HP {get; set;}
    public double Damage {get; set;}
    public int Armor {get; set;}
    public int Affinity {get; set;}
    public double Experience {get; set;}
    public int Level {get; set;}
    public List<Item> inventory;
    public Hero(string name, double hp, double damage, double experience, int level, int armor, int affinity)
    {
        Name = name;
        HP = hp;
        Damage = damage;
        Armor = armor;
        Affinity = affinity;
        Experience = experience;
        Level = level;
        inventory = new List<Item>();
    }
    public void Attack(Character other)
    {
        other.HP -= Damage;
        HP -= other.Damage;
    }
    public void Defence(Character other)
    {
        HP -= other.Damage*0.25;
    }
    public void ItemAttack(Character other, ThrowWeapons item)
    {
        other.HP -= item.Damage;
        item.Amount -= 1;
        if(item.Amount == 0)
            RemoveInventory(item);
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
    public void HandelInventory(Character other)
    {
        if(Inventory().Count == 0){
            Console.WriteLine("Your inventory is empty!");
            return;
        }
        ShowInventory();
        int ItemChoice = int.Parse(Console.ReadLine());
        Item item = Inventory()[ItemChoice - 1];
        if(item is ThrowWeapons throwWeapons)
            ItemAttack(other, throwWeapons);
        
    }
    public void AddInventory(Item item)
    {
        inventory.Add(item);
    }
    public void RemoveInventory(Item item)
    {
        inventory.Remove(item);
    }

    public string Engagement(Character other)
    {
        Console.WriteLine("[A]ttack [D]efense [I]nventory");
        string choice = Console.ReadLine().ToLower();
        switch(choice){
            case "a": 
                Attack(other);
                break;
            case "d":
                Defence(other);
                break;
            case "i":
                HandelInventory(other);
                break;
            }
        return $"Enemy hp: {other.HP} \nPlayer damage: {Damage}\nPlayer hp: {HP} \nEnemy damage: {other.Damage}";
    }
}