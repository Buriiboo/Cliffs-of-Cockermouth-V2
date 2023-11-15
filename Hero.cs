using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Game;


namespace HeroBase
{
    public class Hero : Character
    {
        public int Level { get; set; }
        public int Experience { get; private set; }

        private const int BaseExperienceRequirement = 15; // Base experience for first level

        private const int TempArmorIncrease = 2;
        private const int TempHPIncrease = 5;

        public int TempArmorBuff { get; private set; } = 0;
        public string HeroName {get; set;}
        public List<Item> inventory;


        public Hero(string heroName, int hp, double damage, int armor, int affinity,int level, int experience)
            : base(hp, damage, armor, affinity)
        {
            HeroName = heroName;
            Level = level;
            Experience = experience;
            inventory = new List<Item>();
            // Any additional initializations specific to Minions can be done here
        }

        public static Hero CreateHero()
        {
            Console.Clear();
            System.Console.WriteLine("Choose a name: ");
            string heroName = Console.ReadLine();

            int hp = 500;
            double damage = 50;
            int armor = 3;
            int affinity = 50;
            int level = 1;
            int experience = 1;

            return new Hero(heroName, hp, damage, armor, affinity, level, experience);
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

        public void Defend()
        {
            // Increase armor temporarily for the battle encounter
            this.Armor += TempArmorIncrease;
            TempArmorBuff += TempArmorIncrease;

            // Increase HP but do not exceed MaxHP
            this.HP = Math.Min(this.HP + TempHPIncrease, this.MaxHP);
        }

        public int Riposte(List<Minions> spawnMinion)
        {
            int totalDamageDealt = 0;

            foreach (var minion in spawnMinion)
            {
                if (minion.HP > 0)
                {
                    double effectiveDamage = (this.Damage / 2) - minion.Armor;
                    effectiveDamage = Math.Max(effectiveDamage, 0); // Ensures damage is not negative

                    if (minion.HP - effectiveDamage <= 0)
                    {
                        effectiveDamage = minion.HP; // Deals only as much HP as the minion has left
                        minion.HP = 0;
                    }
                    else
                    {
                        minion.HP -= (int)effectiveDamage;
                    }

                    totalDamageDealt += (int)effectiveDamage;
                }
            }

            return totalDamageDealt;
        }

        public int Spell(Character target, Abilities offensive)
        {
            double effectiveDamage = offensive.Power;
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


        public void AddExperience(int experienceGained)
        {
            Experience += experienceGained;
            CheckForLevelUp();
        }

        private void CheckForLevelUp()
        {
            while (Experience >= ExperienceRequiredForLevel(Level))
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            // Implement any additional logic needed when leveling up
        }

        private int ExperienceRequiredForLevel(int level)
        {
            return BaseExperienceRequirement * (int)Math.Pow(2, level - 1);
        }

        
        public List<Item> Inventory()
        {
            return inventory;
        }
        public void ShowInventory()
        {
            for(int i = 0; i < inventory.Count; i++){
                Console.WriteLine($"{i + 1}: {inventory[i].Name}");
            }
        }
        public void HandelInventory(Character other) // det finns just nu bara för ThrowWeapons item för det är den enda sorten som har lagts till.
        {
            if(Inventory().Count == 0){
                Console.WriteLine("Your inventory is empty!");
                return;
            }
            ShowInventory();
            int ItemChoice = int.Parse(Console.ReadLine());
            Item item = Inventory()[ItemChoice - 1];
            if(item is ThrowWeapons throwWeapons){
                item.UseItem(other);
                if(throwWeapons.Amount == 0)
                    RemoveInventory(item);
            }
        }

        public void AddInventory(Item item)
        {
            inventory.Add(item);
        }
        public void RemoveInventory(Item item)
        {
            inventory.Remove(item);
        }
    }

}

