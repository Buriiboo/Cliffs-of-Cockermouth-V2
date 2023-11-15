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

            int playerRow = 2;
            int playerColumn = 1;
            bool isRunning = true;
            Hero hero = new Hero(500,50,3,50,1,1);

            hero.Heroabilities.AddRange(new Abilities[] 
            {
                Fireball.CreateFireball(),
                IceShard.CreateIceShard(),
                HolyStrike.CreateSmite()
            });


            List<Character> characters = Character.GetDefaultCharacters();
            List<Abilities> abilities = Abilities.GetAbilities();
        

            List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();
            
            List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, hero.Level, 3);
            List<Minions> Boss = Minions.Boss();
            GameLogic.MainMenu();
            GameEnvironment gameEnvironment = new GameEnvironment();
            gameEnvironment.RunGame(allMinions, hero);



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



            }

    
}

}

