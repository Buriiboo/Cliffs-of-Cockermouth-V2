
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
    public List<Item> Inventory()
    {
        return inventory;
    }
    public void ShowInventory()
    {
        for(int i = 0; i < inventory.Count; i++){
            Console.WriteLine($"{i + 1}: {inventory[i].Name}");
        }
    }
    public void HandelInventory(Character other) // det finns just nu bara för ThrowWeapons item för det är den enda sorten som har lagts till.e
    {
        if(Inventory().Count == 0){
            Console.WriteLine("Your inventory is empty!");
            return;
        }
        ShowInventory();
        int ItemChoice = int.Parse(Console.ReadLine());
        Item item = Inventory()[ItemChoice - 1];
        if(item is ThrowWeapons throwWeapons){
            item.UseItem(other);
            if(throwWeapons.Amount == 0)
                RemoveInventory(item);
        }
    }

    public void AddInventory(Item item)
    {
        inventory.Add(item);
    }
    public void RemoveInventory(Item item)
    {
        inventory.Remove(item);
    }

    public string Encounter(Character other)
    {
        Console.WriteLine("[A]ttack [D]efense [I]nventory");
        string choice = Console.ReadLine().ToLower();
        switch(choice){
            case "a": 
                other.HP -= Damage;
                HP -= other.Damage;
                break;
            case "d":
                HP -= other.Damage*0.25;
                break;
            case "i":
                HandelInventory(other); //här får man väälja ifall det ska vara item attack som ges istället för vanliga player damage. även välja vilket item man vill attackera med
                break;
            }
        return $"Enemy hp: {other.HP} \nPlayer damage: {Damage}\nPlayer hp: {HP} \nEnemy damage: {other.Damage}";
    }
}