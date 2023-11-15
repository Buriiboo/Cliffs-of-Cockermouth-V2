using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Game
{
    public class GameEnvironment
    {
        private Room currentRoom;
        private int playerRoomRow;
        private int playerRoomCol;

        public GameEnvironment()
        {
            currentRoom = new Room();
            playerRoomRow = 3;
            playerRoomCol = 1;
        }

        public void RunGame()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                currentRoom.Print();
                Console.WriteLine("Use W, A, S, D to move. Press 'Q' to quit.");

                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case 'w': currentRoom.MovePlayer(-1, 0); break;
                    case 's': currentRoom.MovePlayer(1, 0); break;
                    case 'a': currentRoom.MovePlayer(0, -1); break;
                    case 'd': currentRoom.MovePlayer(0, 1); break;
                    case 'q': isRunning = false; continue;
                }

                CheckRoomTransition();
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