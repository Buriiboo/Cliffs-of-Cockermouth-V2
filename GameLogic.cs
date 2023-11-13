using CharacterBase;
using MinionCreatorBase;
using Game;
using HeroCreatorBase;

public class GameLogic
{Character other;
    public void PrintGrid(int[,] grid, int playerRow, int playerColumn, bool[,] visitedRooms)
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
                        Console.Write(" - ");
                    }
                }
            Console.WriteLine();
            }
        }
    public void MovePlayer(ref int playerRow, ref int playerColumn, string command,bool[,] visitedRooms, int[,] grid, Hero player)
    {
        int newRow = playerRow;
        int newColumn = playerColumn;
        List<Character> characters = DefaultCharacters.GetDefaultCharacters();
        

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
            playerRow = newRow;
            playerColumn = newColumn;
        
            if(newRow == 2 && newColumn == 2){
                other = characters.OfType<Merchant>().FirstOrDefault();
                other.Encounter(player);
            }

            else if(newRow == 0 && newColumn == 1){
                Console.WriteLine("BOSSFIGHT");
                other = characters.OfType<Boss>().FirstOrDefault();
                while(player.HP > 0 && other.HP > 0){
                    Console.WriteLine(player.Engagement(other));
                }
            }
            else if(!visitedRooms[newRow, newColumn]){
                visitedRooms[playerRow, playerColumn] = true; // Mark the old room as visited
                other = DefaultCharacters.GetRandomMinion(DefaultCharacters.GetDefaultCharacters());
                while(player.HP > 0 && other.HP > 0){
                    Console.WriteLine(player.Engagement(other));
                }
            }
        }
    }
}