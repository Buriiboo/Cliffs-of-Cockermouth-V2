using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Game
{
    public class GameLogic
    {


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


        public static void SecretScenario(Hero hero)
        {
      
                System.Console.WriteLine("What is your answer?");
                string answer = Console.ReadLine()?.ToLower();
                if (answer == "melon")
                {
                    System.Console.WriteLine("Your token of friendship has elevated your affinity!");
                    hero.Affinity += 5;
                    System.Console.WriteLine($"New affinity: {hero.Affinity}!");
                }
                  
            Console.ReadKey();

        }


        public static void PlayerTurn(Hero hero, List<Minions> spawnedMinions)
        {
            
            int choice = GetValidChoice(1, 6);

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

                case 4:
                    
                    int abilityChoice = hero.SpellList(hero.Heroabilities);
                    int minionIndex3 = SelectMinionToAttack
                    (spawnedMinions);
                   

                    // Check if the selected minion index is within the bounds of the spawnedMinions list
                    if (minionIndex3 >= 0)
                    {
                        hero.Heroabilities[abilityChoice-1].UseAbility(spawnedMinions[minionIndex3]);
                    }
                    
                    break;
                case 5:
                    int itemChoice = hero.HandleBattleInventory(hero.HeroConsumables);
                    Consumable selectedItem = hero.HeroConsumables[itemChoice - 1];

                    if(selectedItem is HealItem waterPouch){
                        waterPouch.UseItem(hero);
                    }
                    else{
                        int minionIndex4 = SelectMinionToAttack(spawnedMinions);
                        if (minionIndex4 >= 0)
                        {
                            hero.HeroConsumables[itemChoice - 1].UseItem(spawnedMinions[minionIndex4]);
                        }
                    }
                    break;

                    //Steg 1.  Öppna Listan med Consumables.
                    //Steg 2.  Välja item från Consumable listan.
                    //Steg 3.  Ta indexet från ConsumableListan och lägg in i en Variebel. 
                    //int ConsumableChoice = HandelInventoryBattles()
                    //Steg 4.  Välj Fiende att attackera. Ta indexet från Från Minions och lägg in i en Variebel. 
                    //int minionIndex4 = SelectMinionToAttack(spawnedMinions);
                    //Steg 5.  Använd Consumable metoden för Indexet i Spells på Indexet för Minons.
                    //hero.inventory[ConsumableChoice-1].UseItem(spawnedMinions[minionIndex3]);

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

        public static void EndRound(List<Minions> spawnedMinions, List<Minions> allMinions,Hero hero)
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
   
                hero.AddExperience(experienceGained);
         

            // Spawn new minions
            List<Minions> newMinions = Minions.SpawnMinion(allMinions, hero.Level, 3);
            spawnedMinions.AddRange(newMinions);

            System.Console.WriteLine($"Totalt exp gathered from battle:{experienceGained} CurrentHeroLevel:{hero.Level}");
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
        public static void MainMenu()
        {
            bool runMain=true;
            while (runMain)
            {

                Console.WriteLine("|| ===================== ||");
                Console.WriteLine("|| CLIFFS OF COCKERMOUTH ||");
                Console.WriteLine("|| ======================||");
                Console.WriteLine("|| 1) New game           ||");
                Console.WriteLine("|| 2) Load game          ||");
                Console.WriteLine("|| 3) ?????????          ||");
                Console.WriteLine("|| 4) Exit               ||");
                Console.WriteLine("|| ===================== ||");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        System.Console.WriteLine("Starting new game!");
                        Hero hero = Hero.CreateHero();
                        Thread.Sleep(1000);
                        
                        runMain = false;
                        break;
                    case "2":
                        System.Console.WriteLine("Under construction!");
                        Thread.Sleep(1000);
                        //load game
                        break;
                    case "3":
                        System.Console.WriteLine("Under construction!");
                        Thread.Sleep(1000);
                        break;
                    case "4":
                        System.Console.WriteLine("Exiting Menu");
                        Thread.Sleep(1000);
                        runMain = false;
                        break;

                }
            }
        }
    }
}