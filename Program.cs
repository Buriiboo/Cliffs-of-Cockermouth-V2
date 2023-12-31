﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.VisualBasic;

//Kör bara main loop och initierar saker.

namespace Game
{
class Program
{
    static void Main(string[] args)
    {
            Console.Write("Choose a name: ");
            string? name = Console.ReadLine();
            Hero hero = new Hero(name, 250,50,3,50,1,1);


        hero.Heroabilities.AddRange(new Abilities[]                                                  //Skapa startobjekt
        {
            new Fireball("Fireball","A ball of fire",40,1),
            new IceShard("IceShard","Ice as sharp as a dagger",20,1),
            new HolyStrike("HolyStrike","a Zealous Strike",30,1)

        });
        hero.inventory.AddRange(new Item[]                                                         //Skapa startItems
        {
            new LeatherHelm("Leather Hat", "Hat made out of leather", false, "Helmet","yellow"), //man kan använda samma för attla olika typer, de gör samma saker
            new LeatherPlate("Leather Shirt", "Shirt made out of leather", false, "Torso","yellow"),
            new LeatherGloves("Leather gloves", "Gloves made out of leather", false, "Gloves","yellow"),
            new LeatherBoots("Leather Boots", "Boots made out of leather", false, "Boots","yellow"),

            //new HelmofDoom("HelmOfDoom", "Heavy helm not for the faint of heart", false, "Helmet","Purple"),                      //   Lagd i Scenario
        //    new PlateofChaos("PlateofChaos","The Rightous fear it, the cunning desire it ",false,"Torso","Purple"),               Lagd i Scenario
            new GlovesofDoom("GlovesOfDoom", "Gloves helm not for the faint of heart", false, "Gloves","Blue"),
            new BootsofChaos("BootsOfChaos", "The Rightous fear it, the cunning desire it", false, "Boots","Blue"),

            new ThrowWeapons("Swamp potion", "Gives out 19 damage", 2, 19),
            new HealItem("Healing potion", "Gives you 12hp", 3, 12),
            new HealItem("WaterPounch", "Gives you 25hp", 2, 25)

        });

        hero.HeroConsumables = hero.inventory.OfType<Consumable>().ToList();
        List<Character> characters = Character.GetDefaultCharacters();                               //Skapar en del av karaktärsobjekten vid start
        //List<Abilities> abilities = Abilities.GetAbilities();
        List<Minions> allMinions = Character.GetDefaultCharacters().OfType<Minions>().ToList();      //Sorterar en lista som att man får en minions
        List<Minions> SpawnMinion = Minions.SpawnMinion(allMinions, hero.Level, 3);                  //Sorterar en SpawnMinion 
        List<Minions> Boss = Minions.Boss();
        List<Minions> Demon = Minions.Demon();

        // GameLogic.MainMenu();                                                                      // Menyun mer UI jsut nu
        GameEnvironment gameEnvironment = new GameEnvironment();                                     //Skapa levelförsta environment
        gameEnvironment.RunGame(allMinions, hero);                                                   // Kör Första environment


    }
}

}

