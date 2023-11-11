using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMinionsFunction
{
    public class Abilities
    {
        public string Name { get; set; }
        public double Power { get; set; }
        public string Element {get; set;}
        public int Turns { get; set; }


        public Abilities(string name, double power, string element, int turns)
        {

            Name = name;
            Power = power;
            Element = element;
            Turns = turns;


        }

        public static List<Abilities> GetAbilities()
        {
            return new List<Abilities>
            {
               Offensive.CreateFireball(),
               Offensive.CreateSmite(),
               Offensive.CreateIceShard(),
            };
        }

       

    }



        public class Offensive : Abilities
    {
        public Offensive(string name, double power, string element, int turns)
            : base(name, power, element, turns)
        {
            // Any additional initializations specific to Murlock can be done here
        }

        public static Offensive CreateFireball()
        {

            string name = "Fireball";
            double power = 40;
            string element = "Fire";
            int turns = 1;

            return new Offensive(name, power, element, turns);
        }

        public static Offensive CreateIceShard()
        {

            string name = "IceShard";
            double power = 15;
            string element = "Ice";
            int turns = 1;

            return new Offensive(name, power, element, turns);
        }
        public static Offensive CreateSmite()
        {

            string name = "Holy Strike";
            double power = 20;
            string element = "Holy";
            int turns = 1;

            return new Offensive(name, power, element, turns);
        }

    }

}