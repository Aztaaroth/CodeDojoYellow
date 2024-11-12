class Player
{
    public string Name;
    public int Health;
    public int Level;
}
    class Enemy
    {
        public string Type;
        public int Health;
        public int Damage;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player
            {
                Name = "Jymie",
                Health = 100,
                Level = 1
            };
            
            Enemy enemy = new Enemy
            {
                Type = "Flumph",
                Health = 50,
                Damage = 10
            };
            
            Console.WriteLine("Player Info:");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Level: {player.Level}");

            Console.WriteLine();
            
            Console.WriteLine("Enemy Info:");
            Console.WriteLine($"Type: {enemy.Type}");
            Console.WriteLine($"Health: {enemy.Health}");
            Console.WriteLine($"Damage: {enemy.Damage}");
        }
    }