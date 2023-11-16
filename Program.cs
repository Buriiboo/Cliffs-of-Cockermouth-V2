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
               
                new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",true,"Helm"),
                new ThrowWeapons("Throwing Knife", "Silent throw that catches the enemy of guard", 5, 15),
                new WaterPouch("WaterPounch", "Gives you 25hp", 2, 25)
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

/*

           while (isRunning == true)
            {
                Console.Clear();

                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    isRunning = false;
                }
                else if(playerRow==2&&playerColumn==1){
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    UI.Secret("The way forward was shut...");
                    UI.Secret("But on the door there was an inscription and it read thus:");
                    UI.Secret("Speak the word friend and you may enter.");
                    GameLogic.SecretScenario(hero);
                   
                }
                else if (playerRow == 2 && playerColumn == 2)
                {
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.SecretScenario(hero);

                }
                else if (playerRow == 0 && playerColumn == 2)
                {
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.SecretScenario(hero);
    
                }
                else if (playerRow == 0 && playerColumn == 1)
                {
                    GameLogic.BattleEncounter(hero, Minions.Boss());

                    GameLogic.EndRound(Boss, allMinions, hero);
                }
                else
                {
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));

                    GameLogic.EndRound(spawnedMinions, allMinions, hero);
                    foreach (var minions in allMinions)
                    {
                        System.Console.WriteLine(minions.HP);
                        Thread.Sleep(200);
                    }
    
                }
            }
            */