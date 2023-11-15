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
using GameRoom;


namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {

                List<Character> characters = Character.GetDefaultCharacters();
                List<Abilities> abilities2 = Abilities.GetAbilities();
                List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();
                //List<Hero> heroes = new List<Hero>();

                GameEnvironment game = new GameEnvironment();
                Stage stage = new Stage();

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
                            stage.RunMainGameLoop(heroes, allMinions);
                            break;
                        case "2":
                            //load game
                            break;
                        case "3":
                            //????
                            break;
                        case "4":
                            runMain = false;
                            break;
                           
                    }
                
        
            }




                }

        
    }

}