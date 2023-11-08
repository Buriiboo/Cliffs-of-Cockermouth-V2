using System.Runtime.CompilerServices;
using CharacterBase;
namespace NpcCreatorBase
{

    class NPC : Character
    {
        public NPC(string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
        {

        }
        public void Dialog()
        {
            //npc dialog metod
        }
    }
}