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
    public Minion Attack(Hero hero, Minion minion)
    {
        minion.HP -= hero.Damage;
        return minion;
    }
    public Hero Defence(Hero hero, Minion minion)
    {
        hero.HP -= minion.Damage*0.25;
        return hero;
    }
}
class Battle{
    public void Engagement(Hero hero, Minion minion)
    {
        Console.WriteLine("[A]ttack or [D]efense");
        string choice = Console.ReadLine().ToLower();
        if(choice == "a")
            hero.Attack(hero, minion);
        else if(choice == "d")
            hero.Defence(hero, minion);
        
    }
}