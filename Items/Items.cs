
using System.Reflection.Metadata.Ecma335;
namespace Game{
    class Item
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Item(string name, string description, bool haveItem)
        {
            Name = name;
            Description = description;
        }
        public void ReciveItem(Item item, Hero hero)
        {
            hero.AddInventory(item);
        }
        public void ViewIems(Hero hero)
        {
            foreach(Item item in hero.inventory)
            {
                Console.WriteLine($"Name: {item.Name}\n Description: {item.Description}");
            }
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
}
