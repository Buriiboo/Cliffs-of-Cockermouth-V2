using System.Runtime.CompilerServices;
namespace Game{
    class NPC : Character
    {
        public NPC(string name, double damage, double hp, int armor, int affinity) 
            : base(name, damage, hp, armor, affinity)
        {
            
        }
        public void Dialog()
        {
            //npc dialog metod
        }
    }
}