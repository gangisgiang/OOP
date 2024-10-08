using System;
using SwinAdventure;

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
                return "I don't understand what you mean by 'move to ...'. Please specify just the direction.";
            }

            if (text.Length < 2)
            {
                return "Where do you want to move?";
            }

            string direction = text[1].ToLower();
            Path path = p.Location.GetPath(direction);

            if (path == null)
            {
                return "You can't move in that direction.";
            }

            p.Location = path.Destination;

            return "You head " + direction + "\n" + path.Description + "\nYou have arrived at " + p.Location.Name;
        }
    }
}
