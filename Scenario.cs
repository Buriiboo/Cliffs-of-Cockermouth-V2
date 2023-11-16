using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Scenario
    {
        private string Description { get; set; }
        private string InitialDialogue { get; set; }
        private Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)> Branches { get; set; }

        public Scenario(
            string description,
            string initialDialogue,
            Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)> branches)
        {
            Description = description;
            InitialDialogue = initialDialogue;
            Branches = branches;
        }

        public void Present(Hero hero)
        {
            Console.Clear();
            var descriptionLength = Description;
            for (int i = 0;i< descriptionLength.Length; i++){
                Console.Write(descriptionLength[i]);
                Thread.Sleep(25);
            }
        
           

            List<string> branchKeys = Branches.Keys.ToList();
            int selectedIndex = 0;
            while (true)
            {

                Console.Clear(); // Clear the console for a cleaner display
                Console.WriteLine(InitialDialogue);

                for (int i = 0; i < branchKeys.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"-> {branchKeys[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"   {branchKeys[i]}");
                    }
                }

                // Use arrow keys to navigate and make a selection
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if ((keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow) && selectedIndex < branchKeys.Count - 1)
                {
                    selectedIndex++;
                }
                else if ((keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow) && selectedIndex < branchKeys.Count - 1)
                {
                    selectedIndex--;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break; // User selected the option, exit the loop
                }
              
            }

            var selectedBranchKey = branchKeys[selectedIndex];
            var selectedBranch = Branches[selectedBranchKey];

            Console.WriteLine(selectedBranch.response);
            selectedBranch.effect(hero);
            Console.WriteLine(selectedBranch.exitDialogue);
        }
        public static Scenario CreateExampleScenario()
        {
            var branches = new Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)>
        {
            { "Give the Water pouch to the creature",
              ("It gulps the water eagerly", hero => hero.Affinity += 5, "It lets out a growl and perishes") },
            { "Take the water pouch for yourself!",
              ("Despair fills it eyes...", hero => hero.Affinity += 10, "It lets out a growl and perishes") },
            { "Crush the filthy creature...",
              ("You hear a crack as your foot is planted...", hero => hero.Affinity -= 5, "It lets out a gurgle and perishes") }
        };

            return new Scenario(
                "On the ground lays a createure of sorts, its gut pierced and bleeding out. It is obvious that it isn't long for this world",
                "The figure looks what seems to be a pouch of water just out of reach...",
                branches);
        }

        private string GetUserChoice()
        {
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine();
        }

        // Implement other methods as needed
    }



}

