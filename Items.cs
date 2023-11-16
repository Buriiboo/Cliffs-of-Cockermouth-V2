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
                new HelmofDoom("HelmOfDoom","Heavy helm not for the faint of heart",true,"Helm"),
                new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",true,"Helm")
            };
        }

    }

    public abstract class Gear : Item
    {
        public string GearSlot { get; set; }
        public bool HaveItem { get; set; }
        public override void UseItem(Character other){}
        public Gear(string name, string description, bool haveItem, string gearSlot)
            : base(name, description) 
        {
            GearSlot = gearSlot;
            HaveItem = haveItem;
 
        }

        public void EquipGear(Hero hero)
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

        public void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
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
    public class WaterPouch : Consumable
    {
        public int Heal {get; set;}
        private Hero hero;
        public WaterPouch(string name, string description, int amount, int heal) : base(name, description, amount)
        {
            Heal = heal;
        }
        public override void UseItem(Character other)
        {
            Amount -= 1;
            hero.HP += Heal;
        }
    }

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


    public class HelmofDoom : Gear
    {
        public HelmofDoom(string name, string description, bool haveItem, string gearSlot)
            : base(name, description, haveItem, gearSlot)
        {
            // Any additional initializations specific to Murlock can be done here
        }
        public void EquipGear(Hero hero)
        {
            if (HaveItem)
            {
                Console.WriteLine("You already have one on you!");
            }
            else
            {
                HaveItem = true;
                hero.Armor+=5;
                hero.Damage+=5;
                hero.Heroabilities.Add(new FistofDoom("FistOfDoom","Strikes with Chaotic power",50,1));
            }
        }

        public void UnEquipGear(Hero hero)
        {
            if (HaveItem)
            {
                HaveItem = false;
                hero.Armor -= 5;
                hero.Damage -= 5;
                FistofDoom abilityToRemove = new FistofDoom("FistOfDoom", "Strikes with Chaotic power", 50, 1);
                hero.Heroabilities.Remove(abilityToRemove);
            }
        }

    }
    public class PlateofChaos : Gear
    {
        public PlateofChaos(string name, string description, bool haveItem, string gearSlot)
            : base(name, description, haveItem, gearSlot)
        {
            // Any additional initializations specific to Murlock can be done here
        }
    }
}