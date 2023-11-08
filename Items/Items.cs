
using System.Reflection.Metadata.Ecma335;
namespace Game{
    public abstract class Item
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public void UseItem(Hero hero, Character enemy, Item item)
        {
            
        }
    }
    class Gear : Item
    {
        public string GearSlot {get; set;}
        public double Protection {get; set;}
        public bool HaveItem {get; set;}
        public Gear(string name, string description, bool haveItem, string gearSlot, double protection) :base(name, description, haveItem)
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
    }
    class Quest : Item
    {
        
    }
}
