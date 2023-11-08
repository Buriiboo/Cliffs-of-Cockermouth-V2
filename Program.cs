﻿using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;
using CharacterBase;
using MinionCreatorBase;

namespace Main;
{

    class Program
    {
         static void Main(string[] args)
         {
        


            bool runMain = true;
            while (runMain)
            {

                Console.WriteLine("|| ===================== ||");
                Console.WriteLine("|| CLIFFS OF COCKERMOUTH ||");
                Console.WriteLine("|| ======================||");
                Console.WriteLine("|| 1) New game           ||");
                Console.WriteLine("|| 2) Load game          ||");     
                Console.WriteLine("|| 3) ?????????          ||");
                Console.WriteLine("|| 4) Exit               || ");
                Console.WriteLine("|| ===================== ||");
                string choice = Console.ReadLine();
                
                switch(choice)
                {
                    case "1":
                        //character creator -> name, class, 
                        Game.Start();
                        
                        break;
                    case "2":
                        
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













        //Caves
        //S B M
        //R . .
        //. . .

        //Forest/Courtyard
        // S . . B .
        // . R . . .
        // . . . M .
        // P . . R .

        //Castle
        //. R R . M . B

        /*
                        //Visual Boss + Secret and Roaming

                        else if(i == SecretRow && j == SecretRow || i == RoamingRow && j == RoamingRow)
                        {
                            Console.Write(" ? "); // P represents the player
                        }
                        else if (i == BossRow && j == BossRow)
                        {
                            Console.Write(" B "); // P represents the player
                        }


                            static void PopulateGrid(int[,] grid, int playerRow, int playerColumn)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (i == playerRow && j == playerColumn)
                        {
                            break;
                        }
                        else if(i==1&&j==1)
                        {
                        //   GenerateEncounterBoss();
                        }
                        else if(Secret==false || MerchantGenerated == false || Roaming == false){
                            if(Secret == false){
                                GeneratedSecret();
                                Secret==true;
                            }
                            else if (Merchant == false)
                            {
                                MerchantGenerated();
                                Merchant == true;
                            }
                            else if (Roaming == false)
                            {
                                RoamingGenerated();
                                Roaming == true;
                            }

                        }
                        else
                        {
                            GenerateEncounter();
                        }
                    }
                    Console.WriteLine();
                }
            }

        Prototyp för rum + environment.

        Position = Index i 2D Array = [1][2] 
        Open South door(down)

        Isthisempty==False;
        Grid[1][2]=False;


        IndexPlats[2][2]
            if(Grid[1][2]==True)
            {
                Encounter();
                Console.WriteLine("Something happens")
                NextRoom();
            }
            else
                {
                    NextRoom();
                }

        1. Rum vi passerat räknas som Isthisempty==True;
        2. Rum laddar en encounter framgångsrikt.
        3. Environmenten populerar med olika typers encounters och visuellt visar det på kartan?

    */