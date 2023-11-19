using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Game
{
    public class Room
    {
        public int[,] Layout { get; private set; }
        public int PlayerRow { get; set; }
        public int PlayerColumn { get; set; }
        public bool IsInitialized { get; set; }

        public Room(int playerRoomRow, int playerRoomCol)
        {
            InitializeLayout(playerRoomRow, playerRoomCol);
            PlayerRow = 5; // Starting position
            PlayerColumn = 1;
            IsInitialized = false;

        }

        public void InitializeLayout(int playerRoomRow, int playerRoomCol)   //Välj Layout för ert rum
        {

            if (playerRoomRow == 1 && playerRoomCol == 1)
            {
                Layout = new int[,] {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 2 && playerRoomCol == 1)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 3 && playerRoomCol == 1)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 1, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 2, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }};
            }
            if (playerRoomRow == 1 && playerRoomCol == 2)
            {
                Layout = new int[,] {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 1 && playerRoomCol == 3)
            {
                Layout = new int[,] {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 2 && playerRoomCol == 2)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 2 && playerRoomCol == 3)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }};
            }
            if (playerRoomRow == 3 && playerRoomCol == 2)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }};
            }
            if (playerRoomRow == 3 && playerRoomCol == 3)
            {
                Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1 },
                { 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }};
            }


        }

        public void MovePlayer(int rowChange, int colChange, int playerRoomRow, int playerRoomCol, Hero hero, List<Minions> allMinions)
        {
            int newRow = PlayerRow + rowChange;
            int newCol = PlayerColumn + colChange;

            if (newRow >= 0 && newRow < Layout.GetLength(0) && newCol >= 0 && newCol < Layout.GetLength(1) && Layout[newRow, newCol] == 0)
            {
                PlayerRow = newRow;
                PlayerColumn = newCol;
            }

            checkForScenario(playerRoomRow, playerRoomCol, hero, allMinions);
        }


        public void checkForScenario(int playerRoomRow, int playerRoomCol, Hero hero, List<Minions> allMinions)
        {

            //First Room
            if (playerRoomRow == 3 && playerRoomCol == 1)
            {
              
                if (PlayerRow == 2 && PlayerColumn == 1) 
                {

                    var scenario = Scenario.Scenario1();
                    scenario.Present(hero);
                }
                if (PlayerRow == 2 && PlayerColumn == 2) 
                {
                    UI.ShowRollowingMessage("It seems that the entrance to the cliffs is guarded...");
                    UI.ShowRollowingMessage("The feeble amphibiants swarm you...");
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.EndRound(spawnedMinions, allMinions, hero);
                }
                if (PlayerRow == 5 && PlayerColumn == 3 || PlayerRow == 4 && PlayerColumn == 4 || PlayerRow == 5 && PlayerColumn == 5)
                {

                    var scenario = Scenario.Scenario2();
                    scenario.Present(hero);
                }
            }
            else if(playerRoomRow == 3 && playerRoomCol == 3){
                if(PlayerRow == 5 && PlayerColumn == 4 || PlayerRow == 4 && PlayerColumn == 5){
                    Merchant merchant = Character.GetDefaultCharacters().OfType<Merchant>().FirstOrDefault();
                    var scenario = Scenario.Scenario7(hero, merchant);
                    scenario.Present(hero);
                }
            }
        }

        public bool IsWallWithOpening(int row, int col)
        {
            if (Layout[row, col] == 1)
            {
                if ((row == 0 && col == 3 && PlayerRow > 0) ||
                    (row == 6 && col == 3 && PlayerRow < 3) ||
                    (col == 0 && row == 3 && PlayerColumn > 0) ||
                    (col == 6 && row == 3 && PlayerColumn < 3))
                {
                    return true;
                }

            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine($"Current Position: {PlayerRow},{PlayerColumn}");
            for (int row = 0; row < Layout.GetLength(0); row++)
            {
                for (int col = 0; col < Layout.GetLength(1); col++)
                {
                    if (row == PlayerRow && col == PlayerColumn)
                    {
                        Console.Write("P "); // Player's position
                    }
                    else if (IsWallWithOpening(row, col))
                    {
                        Console.Write("# "); // Opening in the wall
                    }
                    else if (Layout[row, col] == 1)
                    {
                        Console.Write("# "); // Wall
                    }
                    else if (Layout[row, col] == 2)
                    {
                        Console.Write("O "); // Merchant
                    }
                    else
                    {
                        Console.Write(". "); // Empty space
                    }
                }
                Console.WriteLine();
            }
        }
    }





}