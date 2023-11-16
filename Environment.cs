using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class GameEnvironment
    {
        public Room currentRoom;
        public int playerRoomRow;
        public int playerRoomCol;
        

        public GameEnvironment()
        {
            playerRoomRow = 3;
            playerRoomCol = 1;
            currentRoom = new Room(playerRoomRow, playerRoomCol);
        }

        public void RunGame(List<Minions> allMinions, Hero hero)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"Current room: {playerRoomRow},{playerRoomCol}");
                currentRoom.Print();
                Console.WriteLine("M=(Map)           I=(Inventory)");
                Console.WriteLine("Use W, A, S, D to move. Press 'Q' to quit.");

                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case 'w': currentRoom.MovePlayer(-1, 0, playerRoomRow, playerRoomCol,hero, allMinions); break;
                    case 's': currentRoom.MovePlayer(1, 0, playerRoomRow, playerRoomCol, hero, allMinions); break;
                    case 'a': currentRoom.MovePlayer(0, -1, playerRoomRow, playerRoomCol, hero, allMinions); break;
                    case 'd': currentRoom.MovePlayer(0, 1, playerRoomRow, playerRoomCol, hero, allMinions); break;
                    case 'i': hero.ShowInventory(); Console.ReadKey(); break;
                //  case 'm'  MapOverview();                            Översikt på rummen och funktion för det.
                    case 'q': isRunning = false; continue;
                }

                //Initiera event på en rumsnivå!
                CheckRoomTransition();
                currentRoom.InitializeLayout(playerRoomRow, playerRoomCol);
                if (playerRoomRow==2 && playerRoomCol==1 && !currentRoom.IsInitialized)         
                {
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
                    GameLogic.BattleEncounter(hero, Minions.SpawnMinion(allMinions, hero.Level, 3));
                    GameLogic.EndRound(spawnedMinions, allMinions, hero);

                    currentRoom.IsInitialized = true;
                }

                if (playerRoomRow == 1 && playerRoomCol == 3 && !currentRoom.IsInitialized)         //Initiera event på en rumsnivå!
                {
                    List<Minions> spawnedMinions = Minions.Boss(); ;
                    GameLogic.BattleEncounter(hero, Minions.Boss());
                    GameLogic.EndRound(spawnedMinions, allMinions, hero); //How do i make this work?

                    currentRoom.IsInitialized = true;
                }


            }
        }

        private void CheckRoomTransition()
        {
            // Ensure that the player cannot move into room (0,0)
            if (currentRoom.PlayerRow == 0 && currentRoom.PlayerColumn == 3 && playerRoomRow > 1) // Move up
            {
                playerRoomRow--;
                currentRoom.PlayerRow = 6; // Adjusted from 4 to 6 to enter from the bottom
            }
            else if (currentRoom.PlayerRow == 6 && currentRoom.PlayerColumn == 3 && playerRoomRow < 3) // Move down
            {
                playerRoomRow++;
                currentRoom.PlayerRow = 0;
            }
            else if (currentRoom.PlayerColumn == 0 && currentRoom.PlayerRow == 3 && playerRoomCol > 1) // Move left
            {
                playerRoomCol--;
                currentRoom.PlayerColumn = 6; // Adjusted from 4 to 6 to enter from the right
            }
            else if (currentRoom.PlayerColumn == 6 && currentRoom.PlayerRow == 3 && playerRoomCol < 3) // Move right
            {
                playerRoomCol++;
                currentRoom.PlayerColumn = 0;
            }
        }
    }

}