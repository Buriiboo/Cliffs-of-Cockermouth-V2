
using System.Reflection.Metadata.Ecma335;
using HeroCreatorBase;
namespace Items;
    public abstract class Item
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    class Gear : Item
    {
        public string GearSlot {get; set;}
        public double Protection {get; set;}
        public bool HaveItem {get; set;}
        public Gear(string name, string description, bool haveItem, string gearSlot, double protection) :base(name, description)
        {
            GearSlot = gearSlot;
            Protection = protection;
            HaveItem = haveItem;
        }
        public void EquipGear(Hero hero, Gear gear)
        {
            if(gear.HaveItem){
                Console.WriteLine("You already have one on you!");
            }
            else{
                HaveItem = true;
                hero.HP += gear.Protection;
            }
        }
        public void UnEquipGear(Hero hero, Gear gear)
        {
            HaveItem = false;
            hero.HP -= gear.Protection;
        }
    }
    class Consumable : Item
    {
        public int Amount {get; set;}
        public Consumable(string name, string description, int amount) :base(name, description)
        {
            Amount = amount;
        }
        public void UseConsumable(Hero hero, Consumable consumable)
        {
            //använd men hur den används beror på om det är något som ger damage ller healtch etc
            hero.RemoveInventory(consumable);
        }
    }
    class Quest : Item
    {
        public bool HaveItem {get; set;}
        public Quest(string name, string description, bool haveItem) :base(name, description)
        {
            HaveItem = haveItem;
        }
        public void UseQuest(Hero hero, Quest quest)
        {
            hero.RemoveInventory(quest);
            //behöver visas också utan console
        }
    }

