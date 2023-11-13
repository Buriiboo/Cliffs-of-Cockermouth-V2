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
    public abstract void Encounter(Hero player);
    
    public Character(string name, double damage, double hp, int armor, int affinity)
    {
        Name = name;
        Damage = damage;
        HP = hp;
        Armor = armor;
        Affinity = affinity;
    }
}
