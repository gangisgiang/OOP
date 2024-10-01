using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) 
        {         

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length > 2)
            {
                return "I don't know how to move there";
            }

            if (text.Length < 2) 
            {
                return "Where do you want to move?";
            }

            string direction = text[1].ToLower();
            Path path = p.Location.Locate(direction) as Path;

            if (path == null)
            {
                return "I don't know how to move there";
            }

            p.Location = path.Destination;

            return "You head " + direction + "\n" + p.Location.Description + "\n" + "You have arrived at " + p.Location.Name;
        }
    }
}


