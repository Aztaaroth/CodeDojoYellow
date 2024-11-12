
static void AttackEnemy()
{
    string enemy = "Flumph";
    int damage = 20;
    Console.WriteLine($"Attacked the {enemy} dealing {damage} damage!");
}

static void HealPlayer()
{
    string playerName = "Jymie";
    int healAmount = 15;
    Console.WriteLine($"Player {playerName} healed {healAmount} health points!");
}

AttackEnemy();
HealPlayer();