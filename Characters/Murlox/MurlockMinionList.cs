using System;
using CharacterBase;
using MinionCreatorBase;
namespace MurlockCreator
{
    public class Murlock : Minions
    {
        public Murlock(string name, int hp, double damage, int armor, int affinity)
            : base(name, damage, hp, armor, affinity)
        {

        }
    }

    public class MurlockList
    {
        public List<Murlock> Murlock { get; }

        public MurlockList()
        {
            Murlock = new List<Murlock>
            {
                new Murlock("Murlock1", 100, 20, 5, 1),
                new Murlock("Murlock2", 80, 15, 4, 2),
                
            };
        }
    }
}