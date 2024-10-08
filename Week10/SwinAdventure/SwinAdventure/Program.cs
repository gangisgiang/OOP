using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Location bedroom = new Location(new string[] { "bedroom" }, "Bedroom", "A big, gorgeous bedroom.");
            Location closet = new Location(new string[] { "closet" }, "Closet", "A small, dark closet with an odd smell.");
            Location kitchen = new Location(new string[] { "kitchen" }, "Kitchen", "A spacious kitchen with an assortment of cooking utensils.");

            Path bedroomToCloset = new Path(new string[] { "south" }, "A narrow door leading south to the closet.", closet);
            Path bedroomToKitchen = new Path(new string[] { "east" }, "A wide archway leading east to the kitchen.", kitchen);
            Path closetToBedroom = new Path(new string[] { "north" }, "A door leading north to the hallway.", bedroom);
            Path kitchenToBedroom = new Path(new string[] { "west" }, "An archway leading west to the hallway.", bedroom);

            bedroom.AddPath(bedroomToCloset);
            bedroom.AddPath(bedroomToKitchen);
            closet.AddPath(closetToBedroom);
            kitchen.AddPath(kitchenToBedroom);

            Player player = new Player("Giang", "A clumsy girl.", bedroom);

            MoveCommand moveCommand = new MoveCommand();

            Console.WriteLine("Welcome to SwinAdventure!\n");
            Console.WriteLine(player.Location.FullDescription);

            while (true)
            {
                Console.Write("\n");
                Console.Write("Enter a command: ");

                string input = Console.ReadLine();

                string[] inputWords = input.Split(' ');

                if (inputWords.Length > 0 && inputWords[0] == "quit")
                {
                    break;
                }
                else

                if (inputWords.Length > 0 && (inputWords[0] == "move" || inputWords[0] == "go" || inputWords[0] == "head" || inputWords[0] == "leave"))
                {
                    string result = moveCommand.Execute(player, inputWords);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Invalid command. Try 'move [direction]' or 'quit'.");
                }
            }
        }
    }
}
