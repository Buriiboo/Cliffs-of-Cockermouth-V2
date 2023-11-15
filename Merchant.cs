/*
public class Merchant : Character
{
    List<Item> inventory;
    public Merchant(string name, double damage, double hp, int armor, int affinity) : base(name, damage, hp, armor, affinity)
    {
        inventory = new List<Item>();
    }
    public void AddInventory(Item item)
    {
        inventory.Add(item);
    }
    public void ShowInventory()
    {
        for(int i = 0; i < inventory.Count; i++){
            Console.WriteLine($"{i + 1}: {inventory[i]}");
        }
    }
    public override void Encounter(Hero player)
    {
        while(true){
            Console.WriteLine("Hi!\n[S]ee what merchant has for sale\n[E]xit");
            string choice = Console.ReadLine().ToLower();
            switch(choice){
                case "s":
                    ShowInventory();
                    Thread.Sleep(3000);
                    break;
                case "e":
                    return;
            }
        }
    }
}
*/