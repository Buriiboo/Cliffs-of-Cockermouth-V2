using CharacterBase;
using Game;
using HeroCreatorBase;
using NpcCreatorBase;

namespace MinionCreatorBase;

public class Minion : Character
{
    public Minion(string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        
    }
    public override void Encounter(Hero player)
    {
        player.HP -= Damage;
        HP -= player.Damage;
    }
    
}


public class Murlock : Minion
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

public class Undead : Minion
{
    public Undead(string name, double hp, double damage, int armor, int affinity)
        : base(name, hp, damage, armor, affinity)
    {
        // Any additional initializations specific to Minions can be done here
    }

}
public class Boss : Minion
{
    
    public double CriticalDamage {get; set;}
    public Boss(string name, double damage, double hp, int armor, int affinity, double criticalDamage) : base(name, damage, hp, armor, affinity)
    {
        CriticalDamage = criticalDamage;
    }
    public void BossCritical(Hero player)
    {
        player.HP -= CriticalDamage + Damage;
    }
    public override void Encounter(Hero player)
    {
        Random random = new Random();
        int nr = random.Next(1, 5);
        if(nr == 3)
            BossCritical(player);
        else
            HP -= player.Damage;
            player.HP -= Damage;
    }
}
public class DefaultCharacters
{
    public static List<Character> GetDefaultCharacters()
    {
        return new List<Character>
        {
        
        
        new Undead("Undead", 30, 12.0, 10, 1),
        new Undead("Undead", 45, 10.5, 10, 1),
        
        new Murlock("Murlock", 25, 15.0, 10, 1),
        new Murlock("Murlock", 50, 15.0, 10, 1),

        new Merchant("Merchant", 3, 25, 5, 2),
        new Boss("Boss", 7, 25, 10, 0, 6),
        //Murlock.CreateBruiser(),
        //Så Kolla hur lite kod och hur lätt som helst
        
        };
    }
    public static Minion GetRandomMinion(List<Character> characters)
    {
        List<Minion> minions = characters.OfType<Minion>().ToList();
        Random random = new Random();
        int index = random.Next(minions.Count);
        return minions[index];
    }
}
   
