using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length < 3)
            {
                return "I don't know how to put that";
            }

            if (text[1] != "in")
            {
                return "What do you want to put in?";
            }

            string itemName = text[0];
            string containerName = text[2];

            if (!p.HasItem(itemName))
            {
                return "I don't know what you want to put in";
            }

            if (!p.HasItem(containerName))
            {
                return "I don't know what you want to put it in";
            }

            Item item = p.GetItem(itemName);
            Item container = p.GetItem(containerName);

            if (container is IHaveInventory)
            {
                IHaveInventory containerInventory = container as IHaveInventory;
                containerInventory.Put(item);
                return "Item " + itemName + " has been put in " + containerName;
            }
            else
            {
                return containerName + " is not a container";
            }
        }
    }
}