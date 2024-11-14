

public interface ISpeak
{
    void Speak();
}

public interface ITrade
{
    void Trade();
}

public interface ICombat
{
    void Attack(ICombat target);
    void TakeDamage(int damage);
    bool IsAlive { get; }
}

public class Player : ISpeak, ICombat
{
    public string Name;
    public int Health;
    public int Level;
    public int Experience;

    public Player(string name, int health, int level)
    {
        Name = name;
        Health = health;
        Level = level;
        Experience = 0;
    }

    public void Attack(ICombat target)
    {
        int damage = 20;
        Console.WriteLine($"{Name} attacks for {damage} damage");
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
    }
    
    public bool IsAlive => Health > 0;

    public void Heal()
    {
        Health += 20;
        Console.WriteLine($"{Name} heals for 20 health. Current Health: {Health}");
    }

    public void GainExperience(int xp)
    {
        Experience += xp;
        Console.WriteLine($"{Name} gains {xp} experience points.");
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Ready for battle!");
    }
}

public class Enemy : ICombat, ISpeak
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

    public void Attack(ICombat target)
    {
        Console.WriteLine($"{Type} attacks for {Damage} damage");
        target.TakeDamage(Damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Type} takes {damage} damage. Health left: {Health}");
    }
    
    public bool IsAlive => Health > 0;

    public void Speak()
    {
        Console.WriteLine($"{Type} floats in an aggressive manner!");
    }
}

public class NPC : ISpeak
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

public class Merchant : ISpeak, ITrade
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
        Console.WriteLine($"{Name} says: Take a look at my wares.");
    }

    public void Trade()
    {
        Console.WriteLine("Available items: " + string.Join(", ", Inventory));
    }
}