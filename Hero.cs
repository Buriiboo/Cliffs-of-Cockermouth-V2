using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;


namespace Game
{
    public class Hero : Character
    {
        public List<Abilities> Heroabilities;   //Aktiv abilities för spellist.
        public List<Item> inventory;            //Inventory man har.
        public List<Consumable> HeroConsumables;
        public int Level { get; set; }
        public int Experience { get; private set; }

        private const int BaseExperienceRequirement = 15; // Base experience for first level
        private const int TempArmorIncrease = 2;       //Temp modifiers
        private const int TempHPIncrease = 5;

        public int TempArmorBuff { get; private set; } = 0;



        public Hero(int hp, double damage, int armor, int affinity,int level, int experience)
            : base(hp, damage, armor, affinity)
        {
            Level = level;
            Experience = experience;
            Heroabilities = new List<Abilities>();
            inventory = new List<Item>();

        }

        public int Attack(Character target)     //Vanlig attack
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

        public int Riposte(List<Minions> spawnMinion)           //CounterAttack
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

        public int SpellList(List<Abilities> Heroabilities) //Välj en ability från spellist
        {

            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < Heroabilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Heroabilities[i].Name}");
            }

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Heroabilities.Count)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number from the list.");
                }
            }
        }


        public void AddExperience(int experienceGained)
        {
            Experience += experienceGained;
            CheckForLevelUp();
        }

        private void CheckForLevelUp()  //Level upChecker
        {
            while (Experience >= ExperienceRequiredForLevel(Level))
            {
                System.Console.WriteLine($"Current Experience: {Experience}, ExperienceRequiredForLevel({Level}): {ExperienceRequiredForLevel(Level)}");
                LevelUp();
            }
        }

        public void LevelUp()   //Level up funktion
        {
            Level++;   
            Experience = 0; // Reset experience to 0 when leveling up

            // Adjust attributes based on the leveling-up logic
            HP += 50;
            Damage += 10;
            Armor += 2;
            

            Console.WriteLine($"{Name} leveled up to level {Level}!");
            Console.WriteLine($"HP: {HP}, Damage: {Damage}, Armor: {Armor}");      

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

        public void ShowBattleInventory()
        {
            for (int i = 0; i < HeroConsumables.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {HeroConsumables[i].Name} Amount:{HeroConsumables[i].Amount}");
               
            }
        }
        public void HandelInventory(Character other)    //Gör om den till passiv/Gear och kopiera en liknade mixad med denna + Spellbook för battle version
        {
            
            if(inventory.Count == 0){
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
        public int HandleBattleInventory(List<Consumable> HeroConsumables)
        {

            ShowBattleInventory();
            Console.WriteLine("Choose an ability:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= HeroConsumables.Count)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number from the list.");
                }
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
        