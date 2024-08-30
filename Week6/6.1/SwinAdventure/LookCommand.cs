using System;
namespace SwinAdventure
{
	public class LookCommand : Command
	{
		public LookCommand()
		{
            Identifiers = new string[] { "look" };
		}

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 || text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }
                IHaveInventory container = p.Locate(text[4]) as IHaveInventory;
                if (container == null)
                {
                    return "I cannot find the " + text[4];
                }
                return container.Locate(text[2]).FullDescription;
            }
            return p.Locate(text[2]).FullDescription;

            
        }


	}
}

