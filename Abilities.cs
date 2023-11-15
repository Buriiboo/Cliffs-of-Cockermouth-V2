using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Abilities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Power { get; set; }
        public int Turns { get; set; }
        public abstract void UseAbility(Character target);


        public Abilities(string name, string description, double power, int turns)
        {

            Name = name;
            Description = description;
            Power = power;
            Turns = turns;

        }



        public static List<Abilities> GetAbilities()
        {
            return new List<Abilities>
            {
               Fireball.CreateFireball(),
               HolyStrike.CreateSmite(),
               IceShard.CreateIceShard(),
            };
        }

       

    }

        public class Fireball : Abilities
    {
        public Fireball(string name, string description, double power, int turns)
            : base(name, description, power, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public static Fireball CreateFireball()
        {

            string name = "Fireball";
            string description = "A ball of fire";
            double power = 40;
            int turns = 1;

            return new Fireball(name, description, power, turns);
        }
        public override void UseAbility(Character target)
        {
            Console.WriteLine("You throw a fireball!");
            int tmp = (int)this.Power;
            target.HP -= tmp;
            
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
            Console.WriteLine("Ice Shard slices your opponent!");
            int tmp = (int)this.Power;
            target.HP -= tmp;
        }

        public static IceShard CreateIceShard()
        {

            string name = "IceShard";
            string description ="Ice as sharp as a dagger";
            double power = 15;
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
            Console.WriteLine("You Strike with Holy power!");
            int tmp = (int)this.Power;
            target.HP -= tmp;
        }


        public static HolyStrike CreateSmite()
        {

            string name = "Holy Strike";
            string description = "Only the most devout can strike True";
            double power = 20;
            int turns = 1;

            return new HolyStrike(name, description, power, turns);
        }

    }

}