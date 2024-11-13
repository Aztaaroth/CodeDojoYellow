
public class Player
{
    public string Name;
    public int Health;
    public int Level;
    public int Experience;
    
    public Player(string name, int health, int level, int experience)
    {
        Name = name;
        Health = health;
        Level = level;
        Experience = experience;
    }
    
    public void Attack(Enemy enemy, int damage)
    {
        Console.WriteLine($"{Name} attacks the {enemy.Type} and deals {damage} damage.");
        enemy.TakeDamage(damage);
    }

    public void GainExperience(int exp)
    {
        Experience += exp;
        Console.WriteLine($"{Name} gains {exp} experience points.");
    }
}

public class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    
    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Console.WriteLine($"{Type} takes {damage} damage. Remaining Health: {Health}. The {Type} is defeated!");
        }
        else
        {
            Console.WriteLine($"{Type} takes {damage} damage. Remaining Health: {Health}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player("Arin", 100, 1, 0);
        Enemy enemy = new Enemy("Orc", 50, 15);
        
        player.Attack(enemy, 20);
        
        player.GainExperience(50);
    }
}