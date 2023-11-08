using HeroCreatorBase;

namespace AbilityBase
{
    public abstract class AbilityBase
    {
        public string Name { get; protected set; } // protected -> för att härstammande klasser kan ändrat dessa egenskaper i konstructorn
        public string Description { get; protected set; }

        public AbilityBase(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void UseAbility();
    }

    public class Fireball : AbilityBase
    {
        public Fireball() : base("Fireball", "Launch a fiery projectile to burn your enemies.")
        {
        }

        public override void UseAbility()
        {
            Console.WriteLine($"Casts {Name}");
            
        }
    }
    public class Regeneration : AbilityBase
    {
        private int remainingTurns;
        public Regeneration() : base("Regeneration", "Forcefully brings out the bodys own regenerative capabilities to it's peak.")
        {
            remainingTurns = 5; // Set the initial number of turns
        }

        public override void UseAbility()
        {
            Console.WriteLine($"Casts {Name}");
            for (int i = 0; i < remainingTurns; i++)
            {
                Hero.HP += 10; // Heal 10 HP each turn
                Console.WriteLine($"Turn {i + 1}: +10 HP");
                if (remainingTurns > 0)
                {
                    remainingTurns--;
                }
            }
            
        }
    }

}
