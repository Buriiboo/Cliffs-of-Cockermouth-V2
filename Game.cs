using HeroCreatorBase;
using CharacterBase;
using MinionCreatorBase;
using MurlockCreator;
using System.Diagnostics.Tracing;
namespace GameLogic
{
    
    public class Game
    {
        public Hero? hero = null;
        private Random random = new Random();
        private MurlockList murlockList = new MurlockList();
     
        public Hero CreateHero()
        {
            Console.Clear();
            Console.Write("Choose a name: ");
            string heroName = Console.ReadLine();

            double hp = 100;
            double damage = 10;
            double experience = 0;
            int level = 1;
            int armor = 5;
            int affinity = 50;  // 0 <- dark aff, 50 -+10 <- neutral aff, 100 <- light aff

            // Create a new Hero instance with the provided attributes
            hero = new Hero(heroName, hp, damage, experience, level, armor, affinity);
            return hero;
        }

        

       

        public void MainGameLoop(Hero hero, List<Character> enemyList)
        {
            int[,] grid = new int[3, 3];
            bool[,] visitedRooms = new bool[3, 3]; // This array keeps track of visited rooms
            int playerRow = 2;
            int playerColumn = 1;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                PrintGrid(grid, playerRow, playerColumn,visitedRooms);

                // Check if the player is in a special room (e.g., a room with an enemy)
                if (IsSpecialRoom(playerRow, playerColumn))
                {
                    Minions randomEnemy = GetRandomEnemy(enemyList);
                    Console.WriteLine($"You encounter an enemy! Prepare for battle!");
                    Battle(hero, randomEnemy);
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
                    MovePlayer(ref playerRow, ref playerColumn, command, visitedRooms,grid);
                }
            }
            

            static void PrintGrid(int[,] grid, int playerRow, int playerColumn, bool[,] visitedRooms)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (i == playerRow && j == playerColumn){
                            Console.Write(" P ");               // P represents the player
                        }
                        else if (i == 0 && j == 1)
                        {
                            Console.Write(" B ");               // B represents Boss
                        }
                        else if(i == 0 && j == 0 && !visitedRooms[i, j])
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
                        else if(!visitedRooms[i, j])
                        {
                            Console.Write(" . ");
                        }
                        else
                        {
                            Console.Write(" . ");
                        }
                    }
                    Console.WriteLine();
                }
            }


            static void MovePlayer(ref int playerRow, ref int playerColumn, string command,bool[,] visitedRooms, int[,] grid)
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
                    
                    if(!visitedRooms[newRow, newColumn])
                    {
                    Battle battle = new Battle();
                    visitedRooms[playerRow, playerColumn] = true; // Mark the old room as visited
                    battle.TriggerBattle(player, other);
                    }
                }
            }

        }

        private bool IsSpecialRoom(int row, int column)
        {
            // Check if the player is in a special room (e.g., a room with an enemy)
            // You can define your criteria for special rooms here.
            return row == 0 && column == 1; // Example: Special room at row 0, column 1
        }

        private double CalculatePlayerDamage(Hero hero)
            {
                //kan lägga till crit, riposte osv
                    return hero.Damage;
            }
        private double CalculateEnemyDamage(Minions randomEnemy)
            {
                    
                    return randomEnemy.Damage;
            }
       public void Battle(Hero hero, Minions randomEnemy)
        {
            bool isBattleActive = true;


            Console.Clear();
            
            Console.WriteLine($"{hero.Name} prepares for battle!!!");
            Console.WriteLine($"a {randomEnemy.Name} appears");
            
           do
            {
                Console.WriteLine("Player's turn:");
                Console.WriteLine("1) Attack");
                Console.WriteLine("2) Defend");
                Console.WriteLine("3) Run Away"); 

                int playerChoice = int.Parse(Console.ReadLine());

                if (playerChoice == 1)
                {
                    double playerDamage = CalculatePlayerDamage(hero); // Implement your damage calculation logic
                    int enemyArmor = randomEnemy.Armor;
                    double damageDealt = Math.Max(playerDamage - enemyArmor, 0);
                }
                else if (playerChoice == 2)
                {
                    // Implement defense logic
                }
                else if (playerChoice == 3)
                {
                    // The player chose to run away
                    isBattleActive = false; // Exit the loop
                }

                // Enemy's turn and other battle logic

                // Check win/loss conditions
                if (hero.HP <= 0)
                {
                    Console.WriteLine($"Game over! {randomEnemy.Name} defeated {hero.Name}.");
                    Console.ReadLine();
                    isBattleActive = false; // Exit the loop
                }
                else if (randomEnemy.HP <= 0)
                {
                    Console.WriteLine($"You defeated {randomEnemy.Name}");
                    Console.WriteLine($"You gained {randomEnemy.Experience}");
                    hero.Experience += randomEnemy.Experience;
                    isBattleActive = false; // Exit the loop
                }
            } while (isBattleActive);

        }
        public Minions GetRandomEnemy(List<Character> enemyList)
        {
            int randomIndex = random.Next(0, enemyList.Count);

            // Return the selected random enemy
            return (Minions)enemyList[randomIndex];
        }

        public List<Character> StageOne()
        {
            List<Character> stageOneEnemies = murlockList.Murlocks.Cast<Character>().ToList();

            // Other stage-specific logic...

            return stageOneEnemies;
        }
    }
}

