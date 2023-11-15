/*
using System.Reflection.Metadata.Ecma335;
using System.Security;
using CharacterBase;
using HeroCreatorBase;
using Microsoft.VisualBasic;
namespace Game;
    public abstract class Item
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public abstract void UseItem(Character other);
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    class Gear
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public string GearSlot {get; set;}
        public double Protection {get; set;}
        public bool HaveItem {get; set;}
        public Gear(string name, string description, bool haveItem, string gearSlot, double protection)
        {
            Name = name;
            Description = description;
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
    public abstract class Consumable : Item
    {
        public int Amount {get; set;}
        public Consumable(string name, string description, int amount) :base(name, description)
        {
            Amount = amount;
        }
    }
    public class Quest
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public bool HaveItem {get; set;}
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
    public class ThrowWeapons : Consumable
    {
        public double Damage {get; set;}
        public ThrowWeapons(string name, string description, int amount, double damage) : base(name, description, amount)
        {
            Damage = damage;
        }
        public override void UseItem(Character other)
        {
            Amount -= 1;
            other.HP -= Damage;
        }
        
    }
    

*/