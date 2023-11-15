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
    }

    public abstract class Gear : Item
    {
        public string GearSlot { get; set; }
        public bool HaveItem { get; set; }
        public override void UseItem(Character other){}
        public Gear(string name, string description, bool haveItem, string gearSlot, int protection)
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
        public double Damage { get; set; }
        public ThrowWeapons(string name, string description, int amount, double damage) : base(name, description, amount)
        {
            Damage = damage;
        }
        public override void UseItem(Character other)
        {
            Amount -= 1;
            other.HP -= Amount;
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
}