using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class UI
    {

        public static void BattleUI(Hero hero, List<Minions> spawnedMinions)
        {

            Console.Clear();
            {
                Console.WriteLine("Previous turn information");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{hero.Name}(HP:{hero.HP} DMG:{hero.Damage} ARM:{hero.Armor})".PadRight(45) +
                                  $"{spawnedMinions[0].Name}".PadRight(5) + $" (HP:{spawnedMinions[0].HP} DMG:{spawnedMinions[0].Damage} ARM:{spawnedMinions[0].Armor})");
                Console.WriteLine($"Placeholder(For friendlies)".PadRight(45) +
                                  $"{spawnedMinions[1].Name}".PadRight(5) + $" (HP:{spawnedMinions[1].HP} DMG:{spawnedMinions[1].Damage} ARM:{spawnedMinions[1].Armor})");
                Console.WriteLine($"Placeholder(For friendlies)".PadRight(45) +
                                  $"{spawnedMinions[2].Name}".PadRight(5) + $" (HP:{spawnedMinions[2].HP} DMG:{spawnedMinions[2].Damage} ARM:{spawnedMinions[2].Armor})");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("Hero's Turn:");
                Console.WriteLine("1. Attack   2. Defend   3. Riposte  4.Spellbook  5.Item Inventory");
            }
        }

        public static void ShowDamageMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }
        public static void ShowRollowingMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(50);
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
    


