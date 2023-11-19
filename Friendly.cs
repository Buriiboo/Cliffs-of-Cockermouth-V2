using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Merchant : Character
    {
        public string Name {get; set;}
        public List<Consumable> merchantInv;
        private Hero hero;
        public Merchant(string name, int hp, double damage, int armor, int affinity) :base(hp, damage, armor, affinity)
        {
            Name = name;
            merchantInv = new List<Consumable>();            
        }
        public static List<Consumable> GetMerchantInv()
        {
            return new List<Consumable>
            {
                new ThrowWeapons("Throwing Knife", "Silent throw that catches the enemy of guard", 1, 15),
                new ThrowWeapons("Swamp potion", "Gives out 19 damage", 1, 19),
                new HealItem("WaterPounch", "Gives you 25hp", 1, 25)

            };
        }
        public void AddInv()
        {
            foreach(Consumable e in GetMerchantInv())
            {
                merchantInv.Add(e);
            }
        }
        public void ShowInventory()
        {
            if(merchantInv.Count == 0)
                AddInv();
            
            for(int i = 0; i < merchantInv.Count; i++)
            {
                if(merchantInv[i] is ThrowWeapons throwWeapons)
                    Console.WriteLine($"{i+1}: {throwWeapons.Name}: {throwWeapons.Description}, {throwWeapons.Damage} damage");
                else if(merchantInv[i] is HealItem healItem)
                    Console.WriteLine($"{i+1}: {healItem.Name}: {healItem.Description}, heals: {healItem.Heal}hp");
            }
        }
        
        public void MerchantMenuUI(Hero hero)
        {
            string choice = Console.ReadLine().ToLower();

            switch(choice){
                case "b":
                    ShowInventory();
                    Console.WriteLine($"Choose an item for 5 affinity or {merchantInv.Count + 1} to exit");
                    if(int.TryParse(Console.ReadLine(), out int indexChoice) && indexChoice > 0 && indexChoice <= merchantInv.Count){
                        Item selectedItem = merchantInv[indexChoice - 1];
                        var existingItem = hero.Inventory().FirstOrDefault(item => item.Name == selectedItem.Name);

                        if (existingItem != null && existingItem is Consumable consumable)
                        {
                            consumable.Amount += 1;
                        }
                        else
                            hero.AddInventory(merchantInv[indexChoice - 1]);
                        hero.Affinity -= 5;
                        return;
                    }
                    else if(indexChoice == merchantInv.Count + 1)
                        return;
                    else
                        Console.WriteLine("Choose an valid option");
                    break;
                    
                case "s": 
                    Console.WriteLine("What whould you like to sell?");
                    hero.ShowInventory();
                    int itemIndex = int.Parse(Console.ReadLine());
                    Consumable itemToSell = hero.HeroConsumables[itemIndex - 1];
                    hero.RemoveInventory(itemToSell); // Antag att det finns en metod som tar bort föremålet från hjältens inventarie
                    merchantInv.Add(itemToSell);
                    hero.Affinity += 5;
                    break;
            }
        }
    }
}
