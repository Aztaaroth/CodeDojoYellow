

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

public class Game()
{
    private Player player;
    private Random random = new Random();

    public void Start()
    {
        do
        {
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 50, 1);
            player.Speak();

            while (player.IsAlive)
            {
                Encounter();
            }
            
            Console.WriteLine("Game Over!");
            
        } while (PlayAgainPrompt());
    }

    private void Encounter()
    {
        int encounterType = random.Next(3);

        switch (encounterType)
        {
            case 0:
                Enemy enemy = new Enemy("Flumph", 30, 15);
                Console.WriteLine($"\nA wild {enemy.Type} appears with {enemy.Health} health and {enemy.Damage} damage!");
                Combat(enemy);
                break;
            
            case 1:
                NPC npc = new NPC("Village Guard", "I used to be an adventurer like you. Then I took an arrow in the knee!");
                Console.WriteLine("\nYou encounter a Village Guard with a bad knee.");
                npc.Speak();
                break;
                
            case 2:
                Merchant merchant = new Merchant("Merchant", new List<string> { "Sword", "Shield", "Potion" });
                Console.WriteLine("\nYou meet a Merchant.");
                merchant.Speak();
                merchant.Trade();
                break;
        }
    }

    private void Combat(Enemy enemy)
    {
        while (player.IsAlive && enemy.IsAlive)
        {
            Console.WriteLine("\nChoose an action:\n1. Attack\n2. Heal");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(enemy);
                if (enemy.IsAlive)
                {
                    enemy.Attack(player);
                }
                else
                {
                    Console.WriteLine($"{enemy.Type} is defeated!");
                    player.GainExperience(30);
                }
            }
            else if (choice == "2")
            {
                player.Heal();
                if (player.IsAlive)
                {
                    enemy.Attack(player);    
                }
                
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    private bool PlayAgainPrompt()
    {
        Console.WriteLine("Would you like to play again? (yes/no): ");
        string choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "yes")
        {
            Console.WriteLine("Restarting the game...\n");
            return true;
        }
        else
        {
            Console.WriteLine("Thank you for playing!");
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}