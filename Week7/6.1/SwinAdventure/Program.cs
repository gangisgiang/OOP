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

            Console.WriteLine("You are " + player.Name + " " + player.Description);

            Item item1 = new Item(new string[] { "sword" }, "sword", "a sharp sword");
            player.Inventory.Put(item1);
            item item2 = new Item(new string[] { "shield" }, "shield", "a strong shield");
            player.Inventory.Put(item2);

            Bag bag = new Bag(new string[] { "bag" }, "bag", "a green bag");
            player.Inventory.Put(bag);

            Item item3 = new Item(new string[] { "coin" }, "coin", "a shiny coin");
            bag.Inventory.Put(item3);

            // Loop reading commands from the user, and getting the look command to execute them

            LookCommand look = new LookCommand();
            string command = "";
            while (command != "quit")
            {
                Console.WriteLine("Enter a command: ");
                command = Console.ReadLine();
                string[] parts = command.Split(' ');
                string result = look.Execute(player, parts);
                Console.WriteLine(result);
            }

            Console.WriteLine("Goodbye!");
        }
    }
}