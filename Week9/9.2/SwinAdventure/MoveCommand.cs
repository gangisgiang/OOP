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
                return "I don't know how to move there";
            }

            if (p.Location.Locate(text[1]) is Path)
            {
                Path path = p.Location.Locate(text[1]) as Path;
                if (path.IsLocked)
                {
                    return "The path is locked";
                }
                else
                {
                    p.Location = path.Destination;
                    return "You have moved to " + path.Destination.Name;
                }
            }
            else
            {
                return "I don't know how to move there";
            }
        }
    }
}