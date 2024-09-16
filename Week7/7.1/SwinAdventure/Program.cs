namespace SwinAdventure
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please describe yourself: ");
            string desc = Console.ReadLine();

            Player player = new Player(name, desc);

            Item item1 = new Item(new string[] { "sword" }, "sword", "sharp sword");
            player.Inventory.Put(item1);
            Item item2 = new Item(new string[] { "shield" }, "shield", "strong shield");
            player.Inventory.Put(item2);

            Bag bag = new Bag(new string[] { "bag" }, "bag", "green bag");
            player.Inventory.Put(bag);

            Item item3 = new Item(new string[] { "coin" }, "coin", "shiny coin");
            bag.Inventory.Put(item3);

            LookCommand look = new LookCommand();

            while (true)
            {
                Console.Write("\nEnter command: ");
                string command = Console.ReadLine();
                string[] parts = command.Split(' ');

                if (parts[0] == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                string result = look.Execute(player, parts);
                Console.WriteLine(result);
            }

        }
    }
}