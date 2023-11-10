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
    public void Attack(Character other)
    {
        other.HP -= Damage;
    }
    public void ItemAttack(Character other, Hero player, ThrowWeapons item)
    {
        other.HP -= item.Damage;
        item.Amount -= 1;
        if(item.Amount == 0)
            player.RemoveInventory(item);
    }

    public void Defence(Character other)
    {
        HP -= other.Damage*0.25;
    }
}
class Battle{
    public string Engagement(Hero player, Character other)
    {
        Console.WriteLine("[A]ttack [D]efense [I]nventory");
        string choice = Console.ReadLine().ToLower();
        switch(choice){
            case "a": 
                player.Attack(other);
                break;
            case "d":
                player.Defence(other);
                break;
            case "i":
                player.HandelInventory(player, other);
                break;
            }
        return $"Enemy hp: {other.HP} \nPlayer damage: {player.Damage}\nPlayer hp: {player.HP} \nEnemy damage: {other.Damage}";
    }
}
