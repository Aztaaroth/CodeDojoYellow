
string[] enemies = { "Goblin", "Orc", "Troll", "Skeleton", "Dragon" };

Console.WriteLine("Enemies:");
foreach (string enemy in enemies)
{
    Console.WriteLine(enemy);
}

List<string> inventory = new List<string> { "Sword", "Shield", "Potion" };

Console.WriteLine("\nPlayer Inventory:");
foreach (string item in inventory)
{
    Console.WriteLine(item);
}

inventory.Add("Helmet");
inventory.Add("Breastplate");
inventory.Remove("Potion");

Console.WriteLine("\nUpdated Inventory:");
foreach (string item in inventory)
{
    Console.WriteLine(item);
}