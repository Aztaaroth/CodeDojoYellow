
public class Player
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
    
    public void Attack(Enemy enemy)
    {
        int damage = 20; // Example of fixed damage
        Console.WriteLine($"{Name} attacks {enemy.Type} and deals {damage} damage.");
        enemy.TakeDamage(damage);
    }
}

public class Enemy
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
}

public class NPC
{
    public string Name;
    public string Dialogue;
    
    public NPC(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }
    
    public void Speak()
    {
        Console.WriteLine($"{Name} says: {Dialogue}");
    }
}

public class Merchant
{
    public string Name;
    public List<string> Inventory;
    
    public Merchant(string name, List<string> inventory)
    {
        Name = name;
        Inventory = inventory;
    }
    
    public void Trade()
    {
        Console.WriteLine($"{Name}'s inventory: {string.Join(", ", Inventory)}");
    }
}

class Program
{
    static void Main()
    {
        // Create a Player, Enemy, NPC, and Merchant
        Player player = new Player("Jymie", 100, 5);
        Enemy goblin = new Enemy("Flumph", 50, 10);
        NPC villager = new NPC("Village Guard", "Welcome to our village!");
        Merchant merchant = new Merchant("Merchant", new List<string> { "Sword", "Shield", "Potion" });
        
        player.Attack(goblin);
        
        villager.Speak();
        
        merchant.Trade();
    }
}