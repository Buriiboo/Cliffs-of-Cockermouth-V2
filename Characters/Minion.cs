namespace Game{
    public class Minions : Character
    {
        public Minions(string name, int hp, double damage, int armor, int affinity)
            : base(name, hp, damage, armor, affinity)
        {
            // Any additional initializations specific to Minions can be done here
        }

    }

    public class Murlock : Minions
    {
        public Murlock(string name, int hp, double damage, int armor, int affinity)
            : base(name, hp, damage, armor, affinity)
        {
            // Any additional initializations specific to Minions can be done here
        }

    }

    public class Undead : Minions
    {
        public Undead(string name, int hp, double damage, int armor, int affinity)
            : base(name, hp, damage, armor, affinity)
        {
            // Any additional initializations specific to Minions can be done here
        }

    }
}