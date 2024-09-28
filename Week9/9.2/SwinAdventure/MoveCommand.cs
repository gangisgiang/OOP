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
            if (text.Length != 2)
            {
                return "I don't know how to move like that";
            }

            if (text[0] != "move")
            {
                return "Error in move input";
            }

            Path path = p.Locate(text[1]) as Path;
            if (path == null)
            {
                return "I cannot find the " + text[1];
            }

            if (path.IsLocked)
            {
                return "The path is locked";
            }

            p.Location = path.Destination;
            return "You have moved to " + path.Destination.Name;
        }
    }
}