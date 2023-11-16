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
            Hero hero = new Hero(500,50,3,50,1,1);

            hero.Heroabilities.AddRange(new Abilities[] 
            {
                new Fireball("Fireball","A ball of fire",40,1),
                new IceShard("IceShard","Ice as sharp as a dagger",20,1),
                new HolyStrike("HolyStrike","a Zealous Strike",30,1)

            });
            hero.inventory.AddRange(new Item[]
           {
                new HelmofDoom("HelmOfDoom","Heavy helm not for the faint of heart",true,"Helm"),
                new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",true,"Helm")
           });



            List<Character> characters = Character.GetDefaultCharacters();
            //List<Abilities> abilities = Abilities.GetAbilities();
        

            List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();
            
            List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, hero.Level, 3);
            List<Minions> Boss = Minions.Boss();
            GameLogic.MainMenu();
            GameEnvironment gameEnvironment = new GameEnvironment();
            gameEnvironment.RunGame(allMinions, hero);


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