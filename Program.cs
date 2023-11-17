using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.VisualBasic;



namespace Game
{
class Program
{
    static void Main(string[] args)
    {
            Console.Write("Choose a name: ");
            string? name = Console.ReadLine();
            Hero hero = new Hero(name, 500,50,3,50,1,1);
           

            hero.Heroabilities.AddRange(new Abilities[]                                                  //Skapa startobjekt
            {
                new Fireball("Fireball","A ball of fire",40,1),
                new IceShard("IceShard","Ice as sharp as a dagger",20,1),
                new HolyStrike("HolyStrike","a Zealous Strike",30,1)

            });
            hero.inventory.AddRange(new Item[]                                                         //Skapa startItems
           {
                new HelmofDoom("HelmOfDoom", "Heavy helm not for the faint of heart", false, "Helm"),
                new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",false,"Torso"),
                new ThrowWeapons("Throwing Knife", "Silent throw that catches the enemy of guard", 5, 15),
                new ThrowWeapons("Swamp potion", "Gives out 19 damage", 2, 19),
                new HealItem("Healing potion", "Gives you 12hp", 3, 12),
                new HealItem("WaterPounch", "Gives you 25hp", 2, 25)

           });

            hero.HeroConsumables = hero.inventory.OfType<Consumable>().ToList();


            List<Character> characters = Character.GetDefaultCharacters();                               //Skapar en del av karaktärsobjekten vid start
            //List<Abilities> abilities = Abilities.GetAbilities();
        
            List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();      //Sorterar en lista som att man får en minions
            
            List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, hero.Level, 3);                  //Sorterar en SpawnMinion 
            List<Minions> Boss = Minions.Boss();

            // GameLogic.MainMenu();                                                                      // Menyun mer UI jsut nu
            GameEnvironment gameEnvironment = new GameEnvironment();                                     //Skapa levelförsta environment
            gameEnvironment.RunGame(allMinions, hero);                                                   // Kör Första environment


            }

    
}

}

