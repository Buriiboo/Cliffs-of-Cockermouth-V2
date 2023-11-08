using HeroCreatorBase;
using CharacterBase;
namespace Game
{
    
    public class Game
    {
        public hero CreateHero(Hero hero, Character character)
        {
            Console.Clear();
        Console.Write("Choose a name: ");
        string characterName = Console.ReadLine();
        return hero;
        }
       



        public void Battle()
                {   
            
                    Console.Clear();
                    
                    Console.WriteLine($"{playerCharacter.Name} prepares for battle!!!");
                    System.Console.WriteLine($"a {Murlock}");
                    
                    do
                    {
                        double attackMultiplier = 1;
                        randomMonster.Damage = monsterDamage;
                        
                        //här vill jag ha kod som gör att man kan välja att slå med item från playerinv eller slå med hand
                        Console.WriteLine("Vill du [1]:Attackera eller [2]Försvara dig?");
                        int choice = int.Parse(Console.ReadLine());
                        if(choice == 1){
                            Console.WriteLine($"Vad vill du använda för att attackera med?");
                            int nr = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine(action.Attack(randomMonster, playerCharacter, nr));
                            playerCharacter.Damage = playerDamage;
                        }
                        else if(choice == 2){
                            Console.WriteLine(action.Defence(randomMonster, playerCharacter, attackMultiplier));
                        }
                        
                        //Få välja om man vill attackera eller defence. Sedan så att defence kan ge parry och därmer 2x damage och tar 0.5x av damage

                        
                    }while (randomMonster.Health > 0 && playerCharacter.Health > 0);

                    if (playerCharacter.Health <= 0)
                    {
                        Console.WriteLine($"Game over! {randomMonster.Name} defeated {playerCharacter.Name}.");
                        Console.ReadLine();
                    }
                    else if (randomMonster.Health <= 0)
                    {
                        Console.WriteLine($"Congratulations! {playerCharacter.Name} defeated {randomMonster.Name}.");
                        playerCharacter.Experience += 150;
                        Console.WriteLine($"You gained {playerCharacter.Experience} exp!");

                        if (playerCharacter.Experience >= 100)
                        {
                            playerCharacter.Level++;
                            Console.WriteLine("Level up!!");
                            Console.WriteLine($"{playerCharacter.Name}'s level increased to {playerCharacter.Level}");
                        }

                        Console.ReadLine();
                    }
                    
                }
        }

   
    }
}