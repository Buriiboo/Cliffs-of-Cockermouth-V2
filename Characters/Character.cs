using System.Security;
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
    
    public Character(string name, double damage, double hp, int armor, int affinity)
    {
        Name = name;
        Damage = damage;
        HP = hp;
        Armor = armor;
        Affinity = affinity;
    }
    public void Attack(Character other, Character player)
    {
        other.HP -= player.Damage;
    }

    public void Defence(Character other, Character player)
    {
        player.HP -= other.Damage*0.25;
    }
}
class Battle{
    public string Engagement(Hero player, Character other)
    {
        Console.WriteLine("[A]ttack [D]efense [I]nventory");
        string choice = Console.ReadLine().ToLower();
        if(choice == "a")
            player.Attack(other, player);
        else if(choice == "d")
            player.Defence(other, player);
        else if(choice == "i"){
            player.ShowInventory();
            int ItemChoice = int.Parse(Console.ReadLine());
            

        }
        return $"Enemy hp: {other.HP} Player damage: {player.Damage}\nPlayer hp: {player.HP} Enemy damage: {other.Damage}";
    }
}