using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Game
{
    public class Hero : Character
    {   
        public string Name{get; set;}
        public List<Abilities> Heroabilities;   //Aktiv abilities för spellist.
        public List<Item> inventory;            //Inventory man har.
        public List<Consumable> HeroConsumables;
        public Dictionary<string, Gear> EquippedGear { get; set; }
        public int Level { get; set; }
        public int Experience { get; private set; }
        private const int BaseExperienceRequirement = 15; // Base experience for first level
        private const int TempArmorIncrease = 2;       //Temp modifiers
        private const int TempHPIncrease = 5;

        public int TempArmorBuff { get; private set; } = 0;

        public Hero(string name, int hp, double damage, int armor, int affinity,int level, int experience)
            : base(hp, damage, armor, affinity)
        {
            Name = name;
            Level = level;
            Experience = experience;

            Heroabilities = new List<Abilities>();
            inventory = new List<Item>();
            HeroConsumables = new List<Consumable>();
            EquippedGear = new Dictionary<string, Gear>();
        }
        
        
            public static Hero CreateHero()
            {
                Console.Clear();
                Console.WriteLine("Choose a name: ");
                string name = Console.ReadLine();

                // You can customize these initial values as needed
                int initialHP = 500;
                double initialDamage = 50;
                int initialArmor = 3;
                int initialAffinity = 50;
                int initialLevel = 1;
                int initialExperience = 1;

                return new Hero(name, initialHP, initialDamage, initialArmor, initialAffinity, initialLevel, initialExperience);
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
            bool inInventory = true;

            while(inInventory){
                System.Console.WriteLine("+++Inventory+++");
                System.Console.WriteLine("1. Show All Items");
                System.Console.WriteLine("2. Show Consumable");
                System.Console.WriteLine("3. Handle Gear");
            //  System.Console.WriteLine("4. Handle Gear");

                int choice= int.Parse(Console.ReadLine());
                switch(choice){

                case 1:
                    Console.Clear();
                    Console.WriteLine("+++All-Items+++");
                    for(int i = 0; i < inventory.Count; i++)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"{i + 1}: {inventory[i].Name}");
                        Console.WriteLine($" {inventory[i].Description}");
        
                    }
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("+++Consumable-Inventory+++");
                    for (int i = 0; i < HeroConsumables.Count; i++)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"{i + 1}: {HeroConsumables[i].Name} amount:{HeroConsumables[i].Amount}");
                        Console.WriteLine($" {HeroConsumables[i].Description}");
                  
                    }
                    Console.WriteLine("Press any key to exit");    
                    Console.ReadKey();
                    break;
                 case 3:
                        Console.Clear();
                        HandleGear();
                        break;
                    
                }
                break;

            
            }
        }
        public void asciiArtInventory()
        {
            System.Console.WriteLine($"{MaxHP}");
            string Helm = EquippedGear.TryGetValue("Helmet", out Gear helmGear) ? $"Equipped: {helmGear.Name}" : "Not Equipped";
            string Torso = EquippedGear.TryGetValue("Torso", out Gear torsoGear) ? $"Equipped: {torsoGear.Name}" : "Not Equipped";
            string Gloves = EquippedGear.TryGetValue("Gloves", out Gear glovesGear) ? $"Equipped: {glovesGear.Name}" : "Not Equipped";
            string Boots = EquippedGear.TryGetValue("Boots", out Gear bootsGear) ? $"Equipped: {bootsGear.Name}" : "Not Equipped";

            string asciiArt = @$"
                <>
               .--.
              /.--.\            Helmet:{Helm}
              |====|
              |`::`|
          .-;`\..../`;-.
         /  |...::...|  \       Torso:{Torso}
        |   /'''::'''\   |
        ;--'\   ::   /\--;
        <__>,>._::_.<,<__>
        |  |/   ^^   \|  |
        \::/|        |\::/      Gloves:{Gloves}
             \_ || _/
             <_ >< _>
             |  ||  |
             |  ||  |
             _\.:||:./_         Boots:{Boots}
             /____/\____\";


            System.Console.WriteLine(asciiArt);
            Console.ReadKey();
        }


        public void ShowBattleInventory()
        {
            for (int i = 0; i < HeroConsumables.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {HeroConsumables[i].Name} Amount:{HeroConsumables[i].Amount}");
               
            }
        }
        public void HandelInventory(Character other, Hero hero)    //Gör om den till passiv/Gear och kopiera en liknade mixad med denna + Spellbook för battle version
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
            Console.WriteLine("Choose an option:");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out int choice);
                if (choice > 0 && choice <= HeroConsumables.Count)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number from the list.");
                }
            }
 
        }
        public void EquipGearFromInventory(string gearName)
        {
            Gear gearToEquip = inventory.OfType<Gear>().FirstOrDefault(g => g.Name == gearName);
            if (gearToEquip != null)
            {
                Console.WriteLine($"Equipping: {gearToEquip.Name}");
                gearToEquip.EquipGear(this);
                EquippedGear[gearToEquip.GearSlot] = gearToEquip;
            }
            else
            {
                Console.WriteLine($"Gear not found in inventory: {gearName}");
            }
        }

        public void HandleGear(){
            Console.Clear();

            string[] gearSlots = { "Helmet", "Torso", "Gloves", "Boots", "Return" };
            int selectedSlotIndex = 0; 

            while (true)
            {
                // Display gear slots with the selected slot highlighted
                Console.Clear();
                Console.WriteLine("+++Gear-Inventory Menu+++");
                for (int i = 0; i < gearSlots.Length; i++)
                {
                    if (i == selectedSlotIndex)
                    {
                        Console.WriteLine($"--> {gearSlots[i]}"); // Highlight the selected slot
                    }
                    else
                    {
                        Console.WriteLine($"    {gearSlots[i]}");
                    }
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read a key press without displaying it
                // Handle arrow key navigation
                if (keyInfo.Key == ConsoleKey.UpArrow && selectedSlotIndex > 0)
                {
                    selectedSlotIndex--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedSlotIndex < gearSlots.Length - 1)
                {
                    selectedSlotIndex++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // When the Enter key is pressed, handle the selected gear slot
                    string selectedSlot = gearSlots[selectedSlotIndex];
                    if (selectedSlot == "Return")
                    {
                        break; // Exit the menu if "Return" is selected
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"+++{selectedSlot}+++");
                        Console.WriteLine(" ");

                        foreach (Item item in inventory)
                        {
                            if (item is Gear gearItem && gearItem.GearSlot == selectedSlot)
                            {
                                Console.WriteLine($"{gearItem.Name}: Info: {gearItem.Description}");
                            }
                        }

                        Console.WriteLine(" ");

                        // Prompt the player to choose an item to equip
                        Console.WriteLine("Choose an item to equip (enter item number) or press any key to go back:");
                        if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice >= 1 && itemChoice <= inventory.Count)
                        {
                            Item selectedItem = inventory[itemChoice - 1];
                            if (selectedItem is Gear selectedGear)
                            {
                                // Call your EquipGearFromInventory method here to equip the selected gear
                                EquipGearFromInventory(selectedGear.Name);
                                Console.WriteLine($"Equipped {selectedGear.Name}.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
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
        