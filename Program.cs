﻿﻿using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;

namespace Main;
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
                    game.Start();
                    
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

        while (isRunning)
        {
            Console.Clear();
            PrintGrid(grid, playerRow, playerColumn,visitedRooms);

            // Display available moves based on the player's current position
            Console.WriteLine("Available Doors:");
            if (playerRow > 0) Console.Write("(Up)".PadRight(4));
            if (playerRow < grid.GetLength(0) - 1) Console.Write("(down)".PadRight(4));
            if (playerColumn > 0) Console.Write("(left)".PadRight(4));
            if (playerColumn < grid.GetLength(1) - 1) Console.Write("(right)".PadRight(4));
            Console.WriteLine("");
            Console.WriteLine("Enter 'exit' to quit.");
            Console.Write("Move: ");

            string command = Console.ReadLine();

            if (command.ToLower() == "exit")
            {
                isRunning = false;
            }
            else
            {
                MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms,grid);
            }
        }
    }

    static void PrintGrid(int[,] grid, int playerRow, int playerColumn, bool[,] visitedRooms)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == playerRow && j == playerColumn){
                    Console.Write(" P ");               // P represents the player
                }
                else if (i == 0 && j == 1)
                {
                    Console.Write(" B ");               // B represents Boss
                }
                else if(i == 0 && j == 0 && !visitedRooms[i, j])
                {
                    System.Console.Write(" S ");        //S represents Secret
                }
                else if (i == 0 && j == 2 && !visitedRooms[i, j])
                {
                    System.Console.Write(" R ");        //R represents Roaming
    
                }
                else if (i == 2 && j == 2)
                {
                    System.Console.Write(" M ");        //M represents Merchant
                }
                else if(!visitedRooms[i, j])
                {
                     Console.Write(" . ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine();
        }
    }


    static void MovePlayer(ref int playerRow, ref int playerColumn, string command,bool[,] visitedRooms, int[,] grid)
    {
        int newRow = playerRow;
        int newColumn = playerColumn;

        switch (command.ToLower())
        {
            case "up":
                newRow -= 1;
                break;
            case "down":
                newRow += 1;
                break;
            case "left":
                newColumn -= 1;
                break;
            case "right":
                newColumn += 1;
                break;
            default:
                Console.WriteLine("Invalid command.");
                return; // Early return if the command is invalid
        }
        if (newRow >= 0 && newRow < grid.GetLength(0) && newColumn >= 0 && newColumn < grid.GetLength(1))
        {
            visitedRooms[playerRow, playerColumn] = true; // Mark the old room as visited
            playerRow = newRow;
            playerColumn = newColumn;
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

public class CharacterCreator
{

}

public class Battle(Hero hero Minions minion)
        
        {   
        }
}