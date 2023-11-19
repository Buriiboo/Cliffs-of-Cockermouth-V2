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
                Thread.Sleep(10);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("Press any key:");
            Console.ReadKey();


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
            int currentHeroAffinity = hero.Affinity;

            Console.WriteLine(selectedBranch.response);
            System.Console.WriteLine("Press any key:");
            Console.ReadKey();
            Console.WriteLine(selectedBranch.exitDialogue);
            selectedBranch.effect(hero);
            System.Console.WriteLine("");
            System.Console.WriteLine($"Hero Affinity change:{hero.Affinity- currentHeroAffinity}");
            System.Console.WriteLine($"Hero Affinity Currently:{hero.Affinity}");
            System.Console.WriteLine($"");
            System.Console.WriteLine("Press any key:");
            Console.ReadKey();
        }
        public static Scenario Scenario1()
        {
            var branches = new Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)>
        {
            { "Give the Water pouch to the creature",
              ("It gulps the water eagerly", hero => hero.Affinity += 5, "It lets out a growl and perishes") },
            { "Take the water pouch for yourself!",
              ("Despair fills it eyes...", hero => hero.Affinity += 10, "It lets out a growl and perishes") },
            { "Crush the filthy creature...",
              ("You hear a crack as your foot is planted...", hero => hero.Affinity -= 10, "It lets out a gurgle and perishes...") }
        };

            return new Scenario(
                "On the ground lays a createure of sorts, its gut pierced and bleeding out. It is obvious that it isn't long for this world",
                "The figure looks what seems to be a pouch of water just out of reach...",
                branches);
        }

        public static Scenario Scenario2()
        {
            var branches = new Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)>
        {

         { "You have no need for pathetic Chaos tainted trinkets...",                                                           
          ("Humming intensifies", hero => {Console.WriteLine("Honorable");hero.Affinity += 10;},"It feels disappointed")            //Option 1
         },

        { "This should Sell for a pretty penny..",
         ("Humming intensifies", hero =>
            {
                HelmofDoom helm = new HelmofDoom("HelmOfDoom", "Heavy helm not for the faint of heart", false, "Helm","Blue");         //Option 2
                hero.inventory.Add(helm);
                Console.WriteLine("It feels pleased");
            },
            "It feels pleased")
        },
        {
            "Finally an artifact worthy of my splendour!",
            ("Humming intensifies violently", hero =>
            {
                HelmofDoom helm = new HelmofDoom("HelmOfDoom", "Heavy helm not for the faint of heart", false, "Helmet","Blue");     //Option 3
                hero.inventory.Add(helm);
                helm.EquipGear(hero);
                hero.Affinity -= 10;
                Console.ReadKey();
            },
            "It feels ecstatic!..No..You Feel ecstatic.")
        }
    };

            return new Scenario(
                "Ah its a Chaos shrine... Ontop of it you see a Helm. The helm is pristine, but the surrounding air distorts around it",
                "One thing is clear, this is no ordinary item and it reeks of Evil",
                branches);
        }
        public static Scenario Scenario3()
        {
            var branches = new Dictionary<string, (string response, Action<Hero> effect, string exitDialogue)>
        {

         { "What am i doing... I need to abandon this path.. I shall.",
          ("The Shrine pulsates violently... and shrieks, it won't let you go that easily", hero =>
            {
                hero.Affinity += 10;
                hero.HP = hero.HP/2;

            },"The shrine sucks half of your life essensce out of you")            //Option 1
         },

        { "Hmm, Why not? Might come in handy",
         ("Humming intensifies", hero =>
            {

                PlateofChaos Torso = new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",false,"Torso","Purple");
                hero.inventory.Add(Torso);
                hero.Affinity -= 2;                          //Option 2
            },
            "It feels pleased")
        },
        {
            "You belong to me..",
            ("Humming intensifies violently", hero =>
            {
                PlateofChaos Torso = new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",false,"Torso","Purple");     //Option 3
                hero.inventory.Add(Torso);
                Torso.EquipGear(hero);
                hero.Affinity -= 10;
                hero.HP += 100;
                Console.ReadKey();

            },
            "Oh, i feel it.. I become.. More.")
        }
    };

            return new Scenario(
                "Ah the Chaos shrine finds me worthy..... Is that an armor materializing ? ",
                "One thing is clear, this is no ordinary item and it smells sweeter than last time..",
                branches);
        }

    }


}
    






