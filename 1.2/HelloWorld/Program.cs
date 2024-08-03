namespace HelloWorld;

internal class Program
{
    static void Main(string[] args)
    {
        Message myMessage = new Message("Hello, World! Greetings from Message Object. My Student ID is 104828510.");

        myMessage.Print();

        string[] Names = { "Phoebe", "Rachel", "Monica" };
        string ad = "Wren";

        while (true)
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            if (name.ToLower() == "exit")
            {
                Console.WriteLine("See Ya!");
                break;
            }

            bool Found = false;

            for (int i = 0; i < Names.Length; i++)
            {
                if (name.ToLower() == Names[i].ToLower())
                {
                    Console.WriteLine($"Hi, {Names[i]}!");
                    Found = true;
                }
            }

            if (!Found)
            {
                if (name.ToLower() == ad.ToLower())
                {
                    Console.WriteLine("Hi Wren the administrator~");
                    Found = true;
                }
            }

            if (!Found)
            {
                Console.WriteLine("Welcome to OOP!");
            }
        }
    }
}