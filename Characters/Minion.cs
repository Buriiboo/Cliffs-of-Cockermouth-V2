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
    public class DefaultCharacters
    {
    public static List<Character> GetDefaultCharacters()
        {
            return new List<Character>
            {
                new Hero("PlayerCharacter", 100, 15.0, 10, 1),

                new Undead("SkeletonWarrior", 30, 12.0, 10, 1),
                new Undead("SkeletonShieldWarrior", 45, 10.5, 10, 1),

                new Murlock("MurlockWorker", 25, 15.0, 10, 1),
                new Murlock("MurlockWarrior", 50, 15.0, 10, 1),

            };
        }
    }
}