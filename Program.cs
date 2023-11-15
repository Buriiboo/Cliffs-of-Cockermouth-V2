using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;
using CharacterBase;
using Game;
using HeroCreatorBase;
using MinionCreatorBase;
using NpcCreatorBase;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic gameLogic = new GameLogic();
            Hero player = new Hero("Hero", 100, 15.0, 10, 1, 15, 50);
            Item arrow = new ThrowWeapons("Arrow", "Sharp", 3, 3);
            player.AddInventory(arrow);
            

            int[,] grid = new int[3, 3];
            bool[,] visitedRooms = new bool[3, 3]; // This array keeps track of visited rooms
            int playerRow = 2;
            int playerColumn = 1;
            bool isRunning = true;

            while (player.HP > 0 || isRunning)
            {
                //Console.Clear();
                gameLogic.PrintGrid(grid, playerRow, playerColumn, visitedRooms);

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
                    gameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid, player);
                }
            }
        }
    }
}
