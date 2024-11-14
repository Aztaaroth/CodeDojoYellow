namespace Kata10;
    
public interface ISpeak
{
    void Speak();
}

public interface ITakeDamage
{
    void TakeDamage(int damage);
}

public class Player : ITakeDamage, ISpeak
{
    public string Name;
    public int Health;
    public int Level;

    public Player(string name, int health, int level)
    {
        Name = name;
        Health = health;
        Level = level;
    }

    public void Attack(ITakeDamage target)
    {
        int damage = 20;
        Console.WriteLine($"{Name} attacks and deals {damage} damage.");
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Ready for battle!");
    }
}

public class Enemy : ITakeDamage, ISpeak
{
    public string Type;
    public int Health;
    public int Damage;

    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
    }

    public void Speak()
    {
        Console.WriteLine($"{Type} growls menacingly!");
    }
}

public class Npc : ISpeak
{
    public string Name;
    public string Dialogue;

    public Npc(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: {Dialogue}");
    }
}

public class Merchant : ISpeak
{
    public string Name;
    public List<string> Inventory;

    public Merchant(string name, List<string> inventory)
    {
        Name = name;
        Inventory = inventory;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: What are you buying, what are you selling?");
    }

    public void Trade()
    {
        Console.WriteLine($"{Name}'s inventory: {string.Join(", ", Inventory)}");
    }
}

class Program
{
    private static void Main()
    {
        // Create a Player, Enemy, NPC, and Merchant
        Player player = new Player("Jymie", 100, 5);
        Enemy goblin = new Enemy("Flumph", 50, 10);
        Npc villager = new Npc("Village Guard", "I used to be an adventurer like you. Then I took an arrow in the knee!");
        Merchant merchant = new Merchant("Merchant", new List<string> { "Sword", "Shield", "Potion" });
        
        player.Attack(goblin);
        
        List<ISpeak> speakers = new List<ISpeak> { player, goblin, villager, merchant };

        foreach (ISpeak speaker in speakers)
        {
            speaker.Speak();
        }
    }
}