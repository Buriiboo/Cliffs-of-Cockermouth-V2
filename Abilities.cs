using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Abilities                             //Abstract Class för vi använder inte detta.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Power { get; set; }
        public int Turns { get; set; }
        public abstract void UseAbility(Character target);     //Sätt Metoden


        public Abilities(string name, string description, double power, int turns)
        {

            Name = name;
            Description = description;
            Power = power;
            Turns = turns;

        }

    }

        public class Fireball : Abilities                    //Abilities
    {
        public Fireball(string name, string description, double power, int turns)
            : base(name, description, power, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public static Fireball CreateFireball()             //CreateFireball så vi skapar den
        {

            string name = "Fireball";
            string description = "A ball of fire";
            double power = 40;
            int turns = 1;

            return new Fireball(name, description, power, turns);
        }
        public override void UseAbility(Character target)  //Använd spell
        {
            Console.WriteLine($"You throw a fireball! Dealing: {this.Power} damage");
            int tmp = (int)this.Power;
            target.HP -= tmp;
            Thread.Sleep(200);

        }
    }


    public class IceShard : Abilities
    {
        public IceShard(string name, string description, double power, int turns)
            : base(name, description, power, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public override void UseAbility(Character target)
        {
            Console.WriteLine($"You throw a Shard of Ice! Dealing: {this.Power} damage");
            int tmp = (int)this.Power;
            target.HP -= tmp;
            Thread.Sleep(200);


        }

        public static IceShard CreateIceShard()
        {

            string name = "IceShard";
            string description ="Ice as sharp as a dagger";
            double power = 20;
            int turns = 1;

            return new IceShard(name, description, power, turns);
        }

    }

    public class HolyStrike : Abilities
    {
        public HolyStrike(string name, string description, double power, int turns)
            : base(name, description, power, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public override void UseAbility(Character target)
        {
            Console.WriteLine($"You Strike with Zeal Dealing: {this.Power} damage");
            int tmp = (int)this.Power;
            target.HP -= tmp;
        }

    }
    public class FistofDoom : Abilities
    {
        public FistofDoom(string name, string description, double power, int turns)
            : base(name, description, power, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public override void UseAbility(Character target)
        {
            Console.WriteLine($"You Strike with Chaos Dealing: {this.Power} damage");
            int tmp = (int)this.Power;
            target.HP -= tmp;
        }

    }


}