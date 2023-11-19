using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Game
{
    public class Room
    {
        private List<bool> scenarioActivationStatus = new List<bool>();         //ANvänd dessa bools för att säkerställa att scenarios i rummen inte aktiveras om och om igen.
        public int[,] Layout { get; private set; }
        public int PlayerRow { get; set; }
        public int PlayerColumn { get; set; }
        public bool IsInitialized { get; set; }

        public Room(int playerRoomRow, int playerRoomCol)
        {

            InitializeLayout(playerRoomRow, playerRoomCol);
            InitializeScenarioActivationStatus();
            PlayerRow = 5; // Starting position
            PlayerColumn = 1;
            IsInitialized = false;

        }
        private void InitializeScenarioActivationStatus()
        {
            //Lägg till en bool för varje nytt scenario som skapas. Inte alla scenarios skall ha bool såsom en Merchant där kan man interagera flera gånger, eller en secret/quest där
            // Lägg gärna Boolsen i kronologisk ordning baserat på interaktionsflödet i ett rum.
            scenarioActivationStatus.Add(false); // Scenario 1    Ingång till Cliffs
            scenarioActivationStatus.Add(false); // Scenario 2    Murlock Encounter
            scenarioActivationStatus.Add(false); // Scenario 3    ChaosArtifact 1
            scenarioActivationStatus.Add(false); // Scenario 4    ChaosArtifact 2
            scenarioActivationStatus.Add(false); // Scenario 5    Murlock Encounter 

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
                { 1, 9, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 1, 1, 1 },
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
                { 1, 0, 1, 0, 1, 1, 1 },
                { 1, 0, 1, 0, 0, 9, 1 },
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
                { 1, 0, 1, 1, 1, 0, 1 },
                { 0, 0, 1, 8, 1, 0, 0 },
                { 1, 0, 1, 0, 1, 0, 1 },
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
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
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
              
                if (PlayerRow == 2 && PlayerColumn == 1 && scenarioActivationStatus[0] == true)         //Tillfälligt true för att testa funktioner förbio
                {

                    var scenario = Scenario.Scenario1();
                    scenario.Present(hero);
                    scenarioActivationStatus[0] = true;

                }
                if (PlayerRow == 2 && PlayerColumn == 2 && scenarioActivationStatus[1] == true)  //Tillfälligt true för att testa funktioner förbio
                {
                   

                    UI.ShowRollowingMessage("It seems that the entrance to the cliffs is guarded...");
                    UI.ShowRollowingMessage("The feeble amphibiants swarm you...");
                    Console.ReadKey();
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.EndRound(spawnedMinions, allMinions, hero);
                    scenarioActivationStatus[1] = true;
                }
                if (PlayerRow == 5 && PlayerColumn == 4 && scenarioActivationStatus[2] == false)
                {
               

                    var scenario = Scenario.Scenario2();
                    scenario.Present(hero);
                    scenarioActivationStatus[2] = true;
                }

                }
            if (playerRoomRow == 2 && playerRoomCol == 1)
            {

                if (PlayerRow == 2 && PlayerColumn == 1 && scenarioActivationStatus[3] == false)
                {

                    if (hero.Affinity < 30)
                    {
                        var scenario = Scenario.Scenario3();
                        scenario.Present(hero);

                        Console.ReadKey();
                        scenarioActivationStatus[3] = true;
                    }
                    else
                    {
                        System.Console.WriteLine("The Chaos Shrine seems to be dormant, you get the feeling it finds you unworthy...");
                        System.Console.WriteLine("Press any key:");
                        Console.ReadKey();
                    }
                }
                if (PlayerRow == 3 && PlayerColumn == 3 && scenarioActivationStatus[4] == false)
                {
                    UI.ShowRollowingMessage("The way is blocked. But not for long...");
                    Console.ReadKey();
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.EndRound(spawnedMinions, allMinions, hero);
                    scenarioActivationStatus[4] = true;
                }



                }
            if (playerRoomRow == 2 && playerRoomCol == 2)
            {

                if (PlayerRow == 4 && PlayerColumn == 3)
                {

                    if (hero.Affinity < 40)
                    {
                        UI.ShowRollowingMessage("The Arena sense your Chaotic ways...");            //Unique Affinity encounters
                        Console.ReadKey();
                        List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        GameLogic.EndRound(spawnedMinions, allMinions, hero);
                        hero.Affinity-=2;

                    }
                    if (hero.Affinity >60)
                    {
                        UI.ShowRollowingMessage("The path of the Rightous rewards..");              //Unique Affinity encounters
                        Console.ReadKey();
                        List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        GameLogic.EndRound(spawnedMinions, allMinions, hero);
                        hero.Affinity += 2;

                    }
                    else
                    {
                        System.Console.WriteLine("The Arena find you unworthy...Choose your path and reutrn.");
                        System.Console.WriteLine("Press any key:");
                        Console.ReadKey();

                    }
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
                    else if (Layout[row, col] == 9)
                    {
                        Console.Write("C "); // ChaosShrine
                    }
                    else if (Layout[row, col] == 8)
                    {
                        Console.Write("A "); // ChaosShrine
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