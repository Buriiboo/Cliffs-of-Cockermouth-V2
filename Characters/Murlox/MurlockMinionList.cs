using System;
using CharacterBase;
using MinionCreatorBase;
using System;
using System.Collections.Generic;  

namespace MurlockCreator
{
    public class Murlock : Minions
    {
        public Murlock(string name, double damage, double hp, double experience, int level, int armor, int affinity)
            : base(name, damage, hp, experience, level, armor,affinity)
        {
        }
    }


    public class MurlockList
    {
        public List<Murlock> Murlocks { get; }

        public MurlockList()
        {
            Murlocks = new List<Murlock>
            {
                new Murlock("Murlock1", 100, 20, 5, 1, 0, 50),
                new Murlock("Murlock2", 80, 15, 4, 2, 1, 50)
            };
        }
    }

}
