using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Room
    {
        public int[,] Layout { get; private set; }
        public int PlayerRow { get; set; }
        public int PlayerColumn { get; set; }

        public Room()
        {
            InitializeLayout();
            PlayerRow = 6; // Starting position
            PlayerColumn = 3;
        }

        private void InitializeLayout()
        {
            Layout = new int[,] {
                { 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1 }
            };
        }

        public void MovePlayer(int rowChange, int colChange)
        {
            int newRow = PlayerRow + rowChange;
            int newCol = PlayerColumn + colChange;

            if (newRow >= 0 && newRow < Layout.GetLength(0) && newCol >= 0 && newCol < Layout.GetLength(1) && Layout[newRow, newCol] == 0)
            {
                PlayerRow = newRow;
                PlayerColumn = newCol;
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
            Console.WriteLine($"Current room: {PlayerRow},{PlayerColumn}");
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
                    else
                    {
                        Console.Write(". "); // Empty space
                    }
                }
                Console.WriteLine();
            }
        }
    }


   public class Stage
    {
            int[,] grid = new int[3, 3];
            bool[,] visitedRooms = new bool[3, 3]; // This array keeps track of visited rooms

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


           

            public void RunMainGameLoop()
            {
                bool isRunning = true;
                List<Character> characters = Character.GetDefaultCharacters();
                List<Abilities> abilities = Abilities.GetAbilities();
            

                List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();
                
                List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, hero.Level, 3);
                List<Minions> Boss = Minions.Boss();

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
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        UI.Secret("The way forward was shut...");
                        UI.Secret("But on the door there was an inscription and it read thus:");
                        UI.Secret("Speak the word friend and you may enter.");
                        GameLogic.SecretScenario(hero);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 2 && playerColumn == 2)
                    {
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        GameLogic.SecretScenario(hero);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 0 && playerColumn == 2)
                    {
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        GameLogic.SecretScenario(hero);
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    }
                    else if (playerRow == 0 && playerColumn == 1)
                    {
                        GameLogic.BattleEncounter(hero, Minions.Boss());
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                        GameLogic.EndRound(Boss, allMinions, hero);
                    }
                    else
                    {
                        List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                        GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                        GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
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
