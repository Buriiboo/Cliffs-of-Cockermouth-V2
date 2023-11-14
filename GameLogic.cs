using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroBase;
using MinionBase;
using UserInterface;
using AbilityBase;
using GameRoom;
using Game;

namespace Game
{
    public class GameLogic
    {


        public static void MovePlayer(ref int playerRow, ref int playerColumn, string command, bool[,] visitedRooms, int[,] grid)
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

        public static void BattleEncounter(Hero hero, List<Minions> spawnedMinions)
        {

        
            while (hero.HP > 0 && spawnedMinions.Any(minion=>minion.HP>0))
            {
                Console.Clear();
                UI.BattleUI(hero, spawnedMinions);

                //Player turn
                PlayerTurn(hero,spawnedMinions);
    

                foreach (var minion in spawnedMinions)
                {
                    if(minion.HP>0){
                    int damageDealt = minion.Attack(hero);
                    UI.ShowDamageMessage($"{minion.Name} attacks Hero and deals {damageDealt} damage.");
                    }
                }
    
            }


            // Loop through each minion in the list and output their information
            foreach (var minion in spawnedMinions)
            {

            }
            Thread.Sleep(3000);

            // Here you would include the logic for the battle encounter
            // For example, you could simulate the hero attacking each minion in turn,
            // and then the minions attacking the hero, updating HP as appropriate.
        }


        public static void SecretScenario(List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                System.Console.WriteLine("What is your answer?");
                string answer = Console.ReadLine()?.ToLower();
                if (answer == "melon")
                {
                    System.Console.WriteLine("Your token of friendship has elevated your affinity!");
                    hero.Affinity += 5;
                    System.Console.WriteLine($"New affinity: {hero.Affinity}!");
                  
                }

            }
            Console.ReadKey();

        }


        public static void PlayerTurn(Hero hero, List<Minions> spawnedMinions)
        {
            
            int choice = GetValidChoice(1, 5);

            switch(choice)
            {
                case 1:
                    int minionIndex = SelectMinionToAttack(spawnedMinions);
                    if (minionIndex >= 0)
                    {
                        int damageDealt = hero.Attack(spawnedMinions[minionIndex]);
                        UI.ShowDamageMessage($"Hero attacks {spawnedMinions[minionIndex].Name} and deals {damageDealt} damage.");
                        break;
                    }
                    break;
                case 2:
                    hero.Defend();
                    UI.ShowDamageMessage($"Hero Defends! Increasing HP by {5} and improves his defense for {hero.TempArmorBuff} damage.");

                    break;
                case 3:
                    int totalDamageDealt = 0;
                    totalDamageDealt = hero.Riposte(spawnedMinions);
                    Console.WriteLine($"Total damage dealt by riposte: {totalDamageDealt}");
                    break;

                case 4:                                                                           //Fireball logiken borde finnas i spells.
                    int minionIndex3 = SelectMinionToAttack(spawnedMinions);
                    Abilities fireball = Offensive.CreateFireball();
                    if (minionIndex3 >= 0)
                    {
                        
                        int damageDealt = hero.Spell(spawnedMinions[minionIndex3], fireball);
                        UI.ShowDamageMessage($"Hero casts {fireball.Name} on {spawnedMinions[minionIndex3].Name} and deals {damageDealt} damage.");
                    }
                    if (minionIndex3 > 0)
                    {
                        int leftDamage = hero.Spell(spawnedMinions[minionIndex3 - 1], fireball);
                        UI.ShowDamageMessage($"The fireball also hits adjecant {spawnedMinions[minionIndex3 - 1].Name}, dealing {leftDamage} damage.");
                    }
                    // Check if there's a minion after the targeted one
                    if (minionIndex3 < spawnedMinions.Count - 1)
                    {
                        int rightDamage = hero.Spell(spawnedMinions[minionIndex3 + 1], fireball);
                        UI.ShowDamageMessage($"The fireball also hits adjecant {spawnedMinions[minionIndex3 + 1].Name}, dealing {rightDamage} damage.");
                    }
                    break;
                   
            }
            


        }

        public static int SelectMinionToAttack(List<Minions> spawnedMinions)
        {
            Console.WriteLine("Choose a minion to attack:");
            for (int i = 0; i < spawnedMinions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {spawnedMinions[i].Name} (HP: {spawnedMinions[i].HP})");
            }

            int choice = GetValidChoice(1, spawnedMinions.Count) - 1;
            return choice;
        }

        public static void EndRound(List<Minions> spawnedMinions, List<Minions> allMinions,List<Hero> heroes, List<Minions> bossGroup)
        {

            //Experience + restore minion
            int totalExperience = 0;
            foreach (var minion in spawnedMinions)
            {
                if (minion.HP <= 0)
                {
                    totalExperience += minion.ExperienceGiven;
                }
                minion.RestoreHP();
            }
            
            int experienceGained = totalExperience;
            foreach (var hero in heroes)
            {
                hero.AddExperience(experienceGained);
            }

            // Spawn new minions
            List<Minions> newMinions = Minions.SpawnMinion(allMinions, heroes.First().Level, 3);
            spawnedMinions.AddRange(newMinions);

            System.Console.WriteLine($"Totalt exp gathered from battle:{experienceGained} CurrentHeroLevel:{heroes.First().Level}");
            System.Console.WriteLine("EndRoundExecuted!");
            Console.ReadKey();

            // Add additional logic here if you need to spawn new characters or perform other end-of-round tasks
        }


        public static int GetValidChoice(int min, int max)
        {
            while (true)
            {
                Console.Write($"Enter your choice ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= min && choice <= max)
                    {
                        return choice;
                    }
                }
                Console.WriteLine("Invalid input. Please enter a number within the specified range.");
            }
        }
    }
    public class Stage
    {
        private int[,] grid = new int[3, 3];
        private bool[,] visitedRooms = new bool[3, 3]; // This array keeps track of visited rooms

        private int playerRow = 2;
        private int playerColumn = 1;
        private bool isRunning = true;
        private List<Minions> spawnedMinions;

        public void RunMainGameLoop(List<Hero> heroes, List<Minions> allMinions)
        {
            GameLogic gameLogic = new GameLogic();

            while (isRunning)
            {
                Console.Clear();

                UI.PrintGrid(grid, playerRow, playerColumn, visitedRooms);
                UI.PlayerMovement(grid, playerRow, playerColumn);

                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    isRunning = false;
                }
                else if (playerRow == 2 && playerColumn == 1)
                {
                    UI.Secret("The way forward was shut...");
                    UI.Secret("But on the door there was an inscription and it read thus:");
                    UI.Secret("Speak the word friend and you may enter.");
                    GameLogic.SecretScenario(heroes);
                    GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                }
                else if (playerRow == 2 && playerColumn == 2)
                {
                    // Insert logic for Merchant
                    GameLogic.SecretScenario(heroes);
                    GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                }
                else if (playerRow == 0 && playerColumn == 2)
                {
                    // Insert logic for Roaming
                    GameLogic.SecretScenario(heroes);
                    GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                }
                else if (playerRow == 0 && playerColumn == 1)
                {
                    List<Minions> bossGroup = Minions.Boss();
                    GameLogic.BattleEncounter(heroes.First(), bossGroup);
                    GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    GameLogic.EndRound(spawnedMinions, allMinions, heroes, bossGroup);
                }

                else
                {
                    List<Minions> bossGroup = Minions.Boss();
                    List<Minions> spawnedMinions = Minions.SpawnMinion(allMinions, heroes.First().Level, 3);
                    GameLogic.BattleEncounter(heroes.First(), Minions.SpawnMinion(allMinions, heroes.First().Level, 3));
                    GameLogic.MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms, grid);
                    GameLogic.EndRound(spawnedMinions, allMinions, heroes, bossGroup);
                    foreach (var minions in allMinions)
                    {
                        System.Console.WriteLine(minions.HP);
                        Thread.Sleep(200);
                    }
                }
            }
        }
    }
}
