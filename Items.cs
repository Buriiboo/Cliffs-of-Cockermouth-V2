using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract void UseItem(Character other);
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public static List<Item> GetItems()
        {
            return new List<Item>
            {
                new HelmofDoom("HelmOfDoom","Heavy helm not for the faint of heart",true,"Helm","Blue"),
                new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",true,"Helm","Blue")
            };
        }

    }

    public abstract class Gear : Item
    {
        public string GearSlot { get; set; }
        public bool HaveItem { get; set; }
        public string Color { get; set; } // Add a Color property specific to Gear

        public override void UseItem(Character other){}
        public Gear(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description) 
        {
            GearSlot = gearSlot;
            HaveItem = haveItem;
            Color = color;
        }

        public virtual void EquipGear(Hero hero)
        {
            if (HaveItem)
            {
                Console.WriteLine("You already have one on you!");
            }
            else
            {
                HaveItem = true;
            }
        }

        public virtual void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
            }
        }
        public static void SetConsoleColor(string color)
        {
            switch (color.ToLower())
            {
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }

    public abstract class Consumable : Item
    {
        public int Amount { get; set; }
        public Consumable(string name, string description, int amount) : base(name, description)
        {
            Amount = amount;
        }
    }

    public class ThrowWeapons : Consumable
    {
        public int Damage { get; set; }
        public ThrowWeapons(string name, string description, int amount, int damage) : base(name, description, amount)
        {
            Damage = damage;
        }
        public override void UseItem(Character other)
        {
            Amount -= 1;
            other.HP -= this.Damage;
        }

    }
    public class HealItem : Consumable
    {
        public int Heal {get; set;}
        public HealItem(string name, string description, int amount, int heal) : base(name, description, amount)
        {
            Heal = heal;
        }
        public override void UseItem(Character other)
        {
            if (other is Hero hero)
            {
                hero.HP += Heal;
            }
            Amount -= 0;
        }
    }

/*
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HaveItem { get; set; }
        public Quest(string name, string description, bool haveItem)
        {
            Name = name;
            Description = description;
            HaveItem = haveItem;
        }
        public void ShowQuest()
        {

        }
    }
*/

    /*
        public class Quest
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool HaveItem { get; set; }
            public Quest(string name, string description, bool haveItem)
            {
                Name = name;
                Description = description;
                HaveItem = haveItem;
            }
            public void ShowQuest()
            {

            }
        }
    */

    public class HelmofDoom : Gear
    {
        public HelmofDoom(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.Affinity -= 2;
                hero.MaxHP += 25;
                hero.Armor += 2;
                hero.Damage += 5;
                hero.Heroabilities.Add(new FistofDoom("FistOfDoom", "Strikes with Chaotic power", 50, 1));
                SetConsoleColor(Color);
                Console.WriteLine($"Equipped {Name}"); // Display the gear item's name in its specified color
                Console.ResetColor();
            }
      
        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = true;
                hero.Affinity += 2;
                hero.MaxHP -= 25;
                hero.Armor -= 2;
                hero.Damage -= 5;

            }
        }

    }


    public class PlateofChaos : Gear
    {
        public PlateofChaos(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
    }
    


    public class GlovesofDoom : Gear
    {
        public GlovesofDoom(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.Affinity -= 2;
                hero.Armor += 1;
                hero.Damage += 15;
                hero.Heroabilities.Add(new FistofDoom("FistOfDoom", "Strikes with Chaotic power", 50, 1));
                SetConsoleColor(Color);
                Console.WriteLine($"Equipped {Name}"); // Display the gear item's name in its specified color
                Console.ResetColor();
            }
        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.Affinity += 2;
                hero.Armor -= 1;
                hero.Damage -= 15;
                FistofDoom abilityToRemove = new FistofDoom("FistOfDoom", "Strikes with Chaotic power", 50, 1);
                hero.Heroabilities.Remove(abilityToRemove);
            }
        }

    }
    public class BootsofChaos : Gear
    {
        public BootsofChaos(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.Affinity -= 2;
                hero.MaxHP += 15;
                hero.Armor += 1;
                hero.Damage += 10;
                SetConsoleColor(Color);
                Console.WriteLine($"Equipped {Name}"); // Display the gear item's name in its specified color
                Console.ResetColor();
            }
        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.Affinity += 2;
                hero.MaxHP -= 15;
                hero.Armor -= 1;
                hero.Damage -= 10;
            }
        }

    }
    
    public class LeatherHelm : Gear
    {
        public LeatherHelm(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot,color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.Affinity -= 1;
                hero.MaxHP += 1;
                hero.Armor += 1;
                hero.Damage += 1;
            }

        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.Armor -= 1;
                hero.Damage -= 1;
            }
        }
    }
    public class LeatherPlate : Gear
    {
        public LeatherPlate(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.Affinity -= 1;
                hero.MaxHP += 1;
                hero.Armor += 1;
                hero.Damage += 1;
            }

        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.Armor -= 1;
                hero.Damage -= 1;
            }
        }
    }
    public class LeatherGloves : Gear
    {
        public LeatherGloves(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot, color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.MaxHP += 5;
                hero.Armor += 1;
            }

        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.MaxHP -= 5;
                hero.Armor -= 1;
              
            }
        }
    }
    public class LeatherBoots : Gear
    {
        public LeatherBoots(string name, string description, bool haveItem, string gearSlot, string color)
            : base(name, description, haveItem, gearSlot,color)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public override void EquipGear(Hero hero)
        {
            if (!HaveItem)
            {
                HaveItem = true;
                hero.MaxHP += 10;
                
            }

        }

        public override void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.MaxHP -= 10;
            }
        }
      
    }

    
    
}