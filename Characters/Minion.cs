using CharacterBase;
using Game;


namespace MinionCreatorBase;

public class Minions : Character
{
    public Minions(string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        itemList = new List<Item>();
    }

}


public class Murlock : Minions
{
    public Murlock(string name, double hp, double damage, int armor, int affinity)
        : base(name, hp, damage, armor, affinity)
    {
        // Any additional initializations specific to Minions can be done here
    }

}
public class MurlockBruiser : Murlock
{
        public int BonusHealth { get; private set; }

        public MurlockBruiser(string name, int hp, double damage, int armor, int affinity)
        : base(name, hp, damage, armor, affinity)
    {

    }

    // MurlockBruiser-specific initialization, if any
}

public class Undead : Minions
{
    public Undead(string name, double hp, double damage, int armor, int affinity)
        : base(name, hp, damage, armor, affinity)
    {
        // Any additional initializations specific to Minions can be done here
    }

}
public class DefaultCharacters
{
    public static List<Character> GetDefaultCharacters()
    {
        return new List<Character>
        {
        new Hero("Hero", 100, 15.0, 10, 1, 15, 50),
        
        new Undead("Undead", 30, 12.0, 10, 1),
        new Undead("Undead", 45, 10.5, 10, 1),
        
        new Murlock("Murlock", 25, 15.0, 10, 1),
        new Murlock("Murlock", 50, 15.0, 10, 1),
        Murlock.CreateBruiser(),
        //Så Kolla hur lite kod och hur lätt som helst
        
        };
    }
}
   
