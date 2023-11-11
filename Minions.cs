using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMinionsFunction
{
    public class Minions : Character
    {
        public int MinionLevel{get;set;}
        public int ExperienceGiven{get;set;}

        

        public Minions(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity)
        {
            MinionLevel = minionlevel;
            ExperienceGiven = experiencegiven;
        }

        public static List<Minions> SpawnMinion(List<Minions> allMinions, int heroLevel, int numberToTake)
        {
            List<Minions> spawnedMinions = new List<Minions>();
            Random rng = new Random();


            int minLevel = Math.Max(1, heroLevel - 1); 
            int maxLevel = heroLevel + 1; 

            var randomMinions = allMinions
                .Where(x => x.MinionLevel >= minLevel && x.MinionLevel <= maxLevel)
                .OrderBy(x => rng.Next())
                .Take(numberToTake)
                .ToList();

            return randomMinions;
        }


        public int Attack(Character target)
        {
            double effectiveDamage = this.Damage - target.Armor;
            if (effectiveDamage < 0)
            {
                effectiveDamage = 0;
            }
            if (target.HP - effectiveDamage < 0)
            {
                effectiveDamage = target.HP;
                target.HP = 0;
            }
            else
            {
                target.HP -= (int)effectiveDamage;
            }
            return (int)effectiveDamage;
        }

        public void RestoreHP()
        {
            HP = MaxHP;
        }

    }




    public class Murlock : Minions
    {
        public Murlock(int hp, double damage, int armor, int affinity, int minionLevel, int experienceGiven)
            : base(hp, damage, armor, affinity, minionLevel, experienceGiven)
        {
            // Any additional initializations specific to Murlock can be done here
        }


        public static MurlockWorker CreateWorker()
        {
            // Predefined stats for MurlockBruiser
            int hp = 35;
            double damage = 10;
            int armor = 0;
            int affinity = 2;
            int minionLevel = 1;
            int experienceGiven = 5;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new MurlockWorker(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static MurlockBruiser CreateBruiser()
        {
            // Predefined stats for MurlockBruiser
            int hp = 50;
            double damage = 20;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 3;
            int experienceGiven = 10;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new MurlockBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static MurlockEliteBruiser CreateEliteBruiser()
        {
            // Predefined stats for MurlockBruiser
            int hp = 75;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 4;
            int experienceGiven = 20;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new MurlockEliteBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

    }

    public class MurlockWorker : Murlock
    {

        public MurlockWorker(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }

    public class MurlockBruiser : Murlock
    {

        public MurlockBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }
    public class MurlockEliteBruiser : Murlock
    {

        public MurlockEliteBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }




    public class Undead : Minions
    {
        public Undead(int hp, double damage, int armor, int affinity,int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel,experiencegiven)
        {
            // Any additional initializations specific to Minions can be done here
        }

    }










}