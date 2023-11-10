﻿using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;
using CharacterBase;
using MinionCreatorBase;
using GameLogic;
using Items;

using System;
using HeroCreatorBase;

namespace MainMenu{

    class Program
    {
        static void Main(string[] args)
        {  
            Game game = new Game();
            List<Character> stageOneEnemies = game.StageOne();
            
        

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
                        Hero hero = game.CreateHero();
                         game.MainGameLoop(hero, stageOneEnemies);
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
      
         }
    }
}
