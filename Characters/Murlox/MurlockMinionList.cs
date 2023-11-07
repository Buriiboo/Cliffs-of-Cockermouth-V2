using System;
using Game;

class Murlock : Minion
{
    public Murlock(string name, int hp, double damage, int armor, int affinity)
        : base(name, damage, hp, armor, affinity)
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
            new Murlock("Murlock1", 100, 20, 5, 1),
            new Murlock("Murlock2", 80, 15, 4, 2),
            // Add more Murlock instances as needed
        };
    }
}
