﻿﻿
class Program
{
    static void Main(string[] args)
    {
        int[,] grid = new int[3, 3];
        bool[,] visited = new bool[3, 3];
        int playerRow = 1;
        int playerColumn = 1;
        bool isRunning = true;
        bool Secret = true;
        bool Roaming = true;

        while (isRunning)
        {
            Console.Clear();
            PrintGrid(grid, playerRow, playerColumn, visited);
            if (!visited[playerRow, playerColumn]){
            
            visited[playerRow, playerColumn] = true;
            }

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
                MovePlayer(ref playerRow, ref playerColumn, command);
            }
        }
    }

    static void PrintGrid(int[,] grid, int playerRow, int playerColumn, bool[,] visited)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == playerRow && j == playerColumn){
                    Console.Write(" P "); // P represents the player
                }
                else if(!visited[i, j]){
                    Console.Write(" . ");
                }
                else
                {
                    Console.Write(" - ");
                }
            }
            Console.WriteLine();
        }
    }

    static void MovePlayer(ref int playerRow, ref int playerColumn, string command)
    {
        switch (command.ToLower())
        {
            case "up":
                if (playerRow > 0) playerRow--;
                break;
            case "down":
                if (playerRow < 2) playerRow++;
                break;
            case "left":
                if (playerColumn > 0) playerColumn--;
                break;
            case "right":
                if (playerColumn < 2) playerColumn++;
                break;
            default:
                Console.WriteLine("Invalid command.");
                break;
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
