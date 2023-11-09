using Game;
using HeroCreatorBase;
using MinionCreatorBase;
namespace CharacterBase;

public abstract class Character
{
    public string Name {get; set;}
    public double Damage {get; set;}
    public double HP {get; set;}
    public int Armor {get; set;}
    public int Affinity {get; set;}
    public List<Item> itemList;
    
    public Character(string name, double damage, double hp, int armor, int affinity)
    {
        Name = name;
        Damage = damage;
        HP = hp;
        Armor = armor;
        Affinity = affinity;
        itemList = new List<Item>();
    }
    public void Attack(Character other, Character player)
    {
        other.HP -= Damage;
    }
    public void Defence(Character other)
    {
        HP -= other.Damage*0.25;
    }
}
class Battle{
    public void Engagement(Character player, Character other)
    {
        Console.WriteLine("[A]ttack or [D]efense");
        string choice = Console.ReadLine().ToLower();
        if(choice == "a")
            player.Attack(other, player);
        else if(choice == "d")
            player.Defence(other);
        
    }
}