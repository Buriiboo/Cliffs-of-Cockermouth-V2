using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class UI
    {

        public static void PrintGrid(int[,] grid, int playerRow, int playerColumn, bool[,] visitedRooms)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == playerRow && j == playerColumn)
                    {
                        Console.Write(" P ");               // P represents the player
                    
                    }
                    else if (i == 0 && j == 1)
                    {
                        Console.Write(" B ");               // B represents Boss
                    }
                    else if (i == 0 && j == 0 && !visitedRooms[i, j])
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
                    else if (visitedRooms[i, j])
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PlayerMovement(int[,] grid, int playerRow, int playerColumn)
        {

            
            if (playerRow > 0) Console.Write("(Up)".PadRight(4));
            if (playerRow < grid.GetLength(0) - 1) Console.Write("(down)".PadRight(4));
            if (playerColumn > 0) Console.Write("(left)".PadRight(4));
            if (playerColumn < grid.GetLength(1) - 1) Console.Write("(right)".PadRight(4));
            Console.WriteLine("");
            Console.WriteLine("Enter 'exit' to quit.");
            Console.Write("Move: ");



        }

        public static void BattleUI(Hero hero, List<Minions> spawnedMinions)
        {

            Console.Clear();
            {
                Console.WriteLine("Previous turn information");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Player(HP:{hero.HP} DMG:{hero.Damage} ARM:{hero.Armor})".PadRight(45) +
                                  $"{spawnedMinions[0].Name}".PadRight(5) + $" (HP:{spawnedMinions[0].HP} DMG:{spawnedMinions[0].Damage} ARM:{spawnedMinions[0].Armor})");
                Console.WriteLine($"Placeholder(For friendlies)".PadRight(45) +
                                  $"{spawnedMinions[1].Name}".PadRight(5) + $" (HP:{spawnedMinions[1].HP} DMG:{spawnedMinions[1].Damage} ARM:{spawnedMinions[1].Armor})");
                Console.WriteLine($"Placeholder(For friendlies)".PadRight(45) +
                                  $"{spawnedMinions[2].Name}".PadRight(5) + $" (HP:{spawnedMinions[2].HP} DMG:{spawnedMinions[2].Damage} ARM:{spawnedMinions[2].Armor})");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("Hero's Turn:");
                Console.WriteLine("1. Attack   2. Defend   3. Riposte  4.Spellbook");
            }
        }

        public static void ShowDamageMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public static void Secret(string message)
        {
            for(int i = 0; i<message.Length;i++){
            Console.Write(message[i]);
            
            Thread.Sleep(25);
            }
            System.Console.WriteLine("");
        }

    }
}
    


