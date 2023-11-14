using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.VisualBasic;
using HeroBase;
using CharacterBase;
using AbilityBase;
using MinionBase;
using UserInterface;
using Game;
using Environment;


namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {

                int[,] grid = new int[3, 3];
                bool[,] visitedRooms = new bool[3, 3]; // This array keeps track of visited rooms

                int playerRow = 2;
                int playerColumn = 1;
                bool isRunning = true;

                
                List<Character> characters = Character.GetDefaultCharacters();
                List<Abilities> abilities2 = Abilities.GetAbilities();
                List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();
                

                List<Hero> heroes = new List<Hero>();
                GameEnvironment game = new GameEnvironment();

                //List<Hero> heroes = Character.GetDefaultCharacters().OfType<Hero>().ToList();
                List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, heroes.First().Level, 3);
                List<Minions> Boss = Minions.Boss();

               
            

                bool runMain = true;
                while (runMain)
                {

                    Console.WriteLine("|| ===================== ||");
                    Console.WriteLine("|| CLIFFS OF COCKERMOUTH ||");
                    Console.WriteLine("|| ======================||");
                    Console.WriteLine("|| 1) New game           ||");
                    Console.WriteLine("|| 2) Load game          ||");     
                    Console.WriteLine("|| 3) ?????????          ||");
                    Console.WriteLine("|| 4) Exit               ||");
                    Console.WriteLine("|| ===================== ||");
                    string choice = Console.ReadLine();
                    
                    switch(choice)
                    {
                        case "1":

                            HeroBase.Hero.CreateHero();
                            game.RunGame();
                            break;
                        case "2":
                            //load game
                            break;
                        case "3":
                            //????
                            break;
                        case "4":
                            return;
                    }
                
        
            }

                while (isRunning == true)
                {
                    Console.Clear();
        
                    UI.PrintGrid(grid, playerRow, playerColumn, visitedRooms);
                    UI.PlayerMovement(grid, playerRow, playerColumn);

                    string command = Console.ReadLine();

                    if (command.ToLower() == "exit")
                    {
                        isRunning = false;
                    }
                    else if(playerRow==2&&playerColumn==1){
                        UI.Secret("The way forward was shut...");
                        UI.Secret("But on the door there was an inscription and it read thus:");
                        UI.Secret("Speak the word friend and you may enter.");
                        GameLogic.SecretScenario(heroes);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 2 && playerColumn == 2)
                    {
                        //Insert logic for Merchant
                        GameLogic.SecretScenario(heroes);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 0 && playerColumn == 2)
                    {
                        //Insert logic for Roaming
                        GameLogic.SecretScenario(heroes);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 0 && playerColumn == 1)
                    {
                        GameLogic.BattleEncounter(heroes.First(), Minions.Boss());
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                        GameLogic.EndRound(Boss, allMinions, heroes);
                    }
                    else
                    {
                        List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, heroes.First().Level, 3);
                        GameLogic.BattleEncounter(heroes.First(), Minions.SpawnMinion(allMinions, heroes.First().Level, 3));
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                        GameLogic.EndRound(spawnedMinions, allMinions, heroes);
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