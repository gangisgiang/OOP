using System;
using SwinAdventure;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        public Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            GameObject item = _inventory.Fetch(id);
            if (item != null)
            {
                return item;
            }

            if (AreYou(id))
            {
                return this;
            }
            
            return null;
        }

        public string FullDescription
        {
            get
            {
                return ("In the " + Name + " you can see:\n" + _inventory.ItemList);
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
	}
}