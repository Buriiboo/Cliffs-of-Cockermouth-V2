using CharacterBase;

namespace MinionCreatorBase;
{
    class Minions : Character
    {
        public Minions(string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
        {
            abilityList = new List<Abilities>();
        }
        public void Engage()
        {
            //engage metod för minions
        }
    }
   
}