using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Character är Föräldraklassen till Minions,Friendlies och Hero

namespace Game
{
    public class Character
    {

        public int MaxHP { get; set; }
        public string Name { get; private set; } // Name is now read-only outside the class
        public int HP { get; set; }
        public double Damage { get; set; }
        public int Armor { get; set; }
        public int Affinity { get; set; }

        public Character(int hp, double damage, int armor, int affinity)
        {

            Name = this.GetType().Name;
            MaxHP = hp;
            HP = hp;
            Damage = damage;
            Armor = armor;
            Affinity = affinity;

        }

        public static List<Character> GetDefaultCharacters()
        {
            return new List<Character>
            {
                Murlock.CreateMurlockKing(),
                Murlock.CreateWorker(),
                Murlock.CreateWorker(),
                Murlock.CreateWorker(),
                Murlock.CreateBruiser(),        
                Murlock.CreateBruiser(),
                Murlock.CreateBruiser(),
                Murlock.CreateEliteBruiser(),
                ChaosDemon.CreateChaosDemon(),
                ChaosImp.CreateChaosImp(),
                ChaosImp.CreateChaosImp(),
                new Merchant("Merchant", 500, 5, 500, 500),

            };
        }


        public int Attack(Character target)
        {
            double effectiveDamage = this.Damage - target.Armor;
            if (effectiveDamage < 0)
            {
                effectiveDamage = 0;
            }
            if (target.HP - effectiveDamage < 0)
            {
                effectiveDamage = target.HP;  
                target.HP = 0;             
            }
            else
            {
                target.HP -= (int)effectiveDamage;
            }
            return (int)effectiveDamage;  
        }

        public void Defend(Character target)
        {
            // Increase armor temporarily for the battle encounter by 2
            this.Armor += 2;
    
        }


    }

}