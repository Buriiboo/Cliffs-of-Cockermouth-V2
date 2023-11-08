using CharacterBase;
using GameLogic;
using Items;


namespace MinionCreatorBase
{
    public class Minions : Character
    {
        public double Experience { get; set; }
        public int Level { get; set; }

        public Minions(string name, double damage, double hp, double experience, int level, int armor, int affinity)
            : base(name, damage, hp, armor, affinity)
        {
            Experience = experience;
            Level = level;
            itemList = new List<Item>();
        }
    }
}
