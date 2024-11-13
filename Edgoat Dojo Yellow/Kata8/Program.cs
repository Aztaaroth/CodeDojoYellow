    
public class Player
{
    private int _health;
    private int _level;
    private int _experience;
    
    public Player(int health = 100, int level = 1, int experience = 0)
    {
        _health = health;
        _level = level;
        _experience = experience;
    }
    
    public int Health
    {
        get { return _health; }
        private set { _health = value; } // Only modifiable within the class
    }

    public int Level
    {
        get { return _level; }
        set
        {
            if (value >= 0)
                _level = value;
            else
                Console.WriteLine("Level cannot be negative.");
        }
    }
    
    public int Experience
    {
        get { return _experience; }
        set
        {
            if (value >= 0)
                _experience = value;
            else
                Console.WriteLine("Experience cannot be negative.");
        }
    }
    
    private void LevelUp()
    {
        _level += 1;
        _experience = 0;
        Console.WriteLine($"Congratulations! You leveled up to Level {_level}.");
    }
    
    public void GainExperience(int exp)
    {
        if (exp < 0)
        {
            Console.WriteLine("Experience points cannot be negative.");
            return;
        }

        _experience += exp;
        Console.WriteLine($"Player gains {exp} experience points.");
        
        if (_experience >= 100) // Exp needed to level up
        {
            LevelUp();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Player player = new Player();
        
        player.GainExperience(50);  // Should just increase experience
        player.GainExperience(60);  // Should level up after reaching 100 experience
        
        Console.WriteLine($"Player Health: {player.Health}");
    }
}