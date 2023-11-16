using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
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

            spawnedMinions = allMinions
                .Where(x => x.MinionLevel >= minLevel && x.MinionLevel <= maxLevel)
                .OrderBy(x => rng.Next())
                .Take(numberToTake)
                .ToList();

            return spawnedMinions;
        }

        public static List<Minions> Boss()
        {
            List<Minions> bossGroup = new List<Minions>();

            // Add one MurlockKing.
            Minions MurlockKing = Murlock.CreateMurlockKing();
            bossGroup.Add(MurlockKing);

            // Add two MurlockEliteBruisers.
            for (int i = 0; i < 2; i++)
            {
                Minions MurlockEliteBruiser = Murlock.CreateEliteBruiser();
                bossGroup.Add(MurlockEliteBruiser);
            }

            return bossGroup;
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

        public static MurlockKing CreateMurlockKing()
        {
            // Predefined stats for MurlockBruiser
            int hp = 150;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 10;
            int experienceGiven = 100;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new MurlockKing(hp, damage, armor, affinity, minionLevel, experienceGiven);
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

    public class MurlockKing : Murlock
    {

        public MurlockKing(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }
        public int Attack(List<Minions> spawnedMinions, Character target)
        {
            if(this.HP>this.MaxHP/2){
                    
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
            else if(this.HP <= this.MaxHP / 2)
            {
                HealingWave(spawnedMinions);
                return 0;

            }
            return 0;
        }

        public void HealingWave(List<Minions> spawnedMinions)
        {
            foreach (var minion in spawnedMinions)
            {
                minion.HP = Math.Min(minion.HP + 20, minion.MaxHP); // Ensure HP doesn't exceed MaxHP
            }

        }

    }


    public class Undead : Minions
    {
        public Undead(int hp, double damage, int armor, int affinity, int minionLevel, int experienceGiven)
            : base(hp, damage, armor, affinity, minionLevel, experienceGiven)
        {
            // Any additional initializations specific to Murlock can be done here
        }


        public static UndeadWorker CreateWorker()
        {
          
            int hp = 35;
            double damage = 10;
            int armor = 0;
            int affinity = 2;
            int minionLevel = 1;
            int experienceGiven = 5;

          
            return new UndeadWorker(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static UndeadBruiser CreateBruiser()
        {
            
            int hp = 50;
            double damage = 20;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 3;
            int experienceGiven = 10;

          
            return new UndeadBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static UndeadEliteBruiser CreateEliteBruiser()
        {
            
            int hp = 75;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 4;
            int experienceGiven = 20;

            
            return new UndeadEliteBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static SkeletonKing CreateSkeletonKing()
        {
            // Predefined stats for MurlockBruiser
            int hp = 150;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 10;
            int experienceGiven = 100;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new SkeletonKing(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

    }

    public class UndeadWorker : Undead
    {

        public UndeadWorker(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        
    }

    public class UndeadBruiser : Undead
    {

        public UndeadBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        
    }

    public class UndeadEliteBruiser : Undead
    {

        public UndeadEliteBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        
    }

    public class SkeletonKing : Undead
    {

        public SkeletonKing(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }
        public int Attack(List<Minions> spawnedMinions, Character target)
        {
            if(this.HP>this.MaxHP/2){
                    
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
            else if(this.HP <= this.MaxHP / 2)
            {
                HealingWave(spawnedMinions);
                return 0;

            }
            return 0;
        }

        public void HealingWave(List<Minions> spawnedMinions)
        {
            foreach (var minion in spawnedMinions)
            {
                minion.HP = Math.Min(minion.HP + 20, minion.MaxHP); // Ensure HP doesn't exceed MaxHP
            }

        }

    }


    public class Orc : Minions
    {
        public Orc(int hp, double damage, int armor, int affinity, int minionLevel, int experienceGiven)
            : base(hp, damage, armor, affinity, minionLevel, experienceGiven)
        {
            // Any additional initializations specific to Murlock can be done here
        }


        public static OrcWorker CreateWorker()
        {
            // Predefined stats for MurlockBruiser
            int hp = 35;
            double damage = 10;
            int armor = 0;
            int affinity = 2;
            int minionLevel = 1;
            int experienceGiven = 5;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new OrcWorker(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static OrcBruiser CreateBruiser()
        {
            // Predefined stats for MurlockBruiser
            int hp = 50;
            double damage = 20;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 3;
            int experienceGiven = 10;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new OrcBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static OrcEliteBruiser CreateEliteBruiser()
        {
            // Predefined stats for MurlockBruiser
            int hp = 75;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 4;
            int experienceGiven = 20;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new OrcEliteBruiser(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

        public static OrcKing CreateOrcKing()
        {
            // Predefined stats for MurlockBruiser
            int hp = 150;
            double damage = 25;
            int armor = 5;
            int affinity = 2;
            int minionLevel = 10;
            int experienceGiven = 100;

            // Return a new instance of MurlockBruiser with the predefined stats
            return new OrcKing(hp, damage, armor, affinity, minionLevel, experienceGiven);
        }

    }

    public class OrcWorker : Orc
    {

        public OrcWorker(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }

    public class OrcBruiser : Orc
    {

        public OrcBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }

    public class OrcEliteBruiser : Orc
    {

        public OrcEliteBruiser(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }

        // MurlockBruiser-specific initialization, if any
    }

    public class OrcKing : Orc
    {

        public OrcKing(int hp, double damage, int armor, int affinity, int minionlevel, int experiencegiven)
            : base(hp, damage, armor, affinity, minionlevel, experiencegiven)
        {

        }
        public int Attack(List<Minions> spawnedMinions, Character target)
        {
            if(this.HP>this.MaxHP/2){
                    
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
            else if(this.HP <= this.MaxHP / 2)
            {
                HealingWave(spawnedMinions);
                return 0;

            }
            return 0;
        }

        public void HealingWave(List<Minions> spawnedMinions)
        {
            foreach (var minion in spawnedMinions)
            {
                minion.HP = Math.Min(minion.HP + 20, minion.MaxHP); // Ensure HP doesn't exceed MaxHP
            }

        }

    }
}




