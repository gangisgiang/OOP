using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = location;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            GameObject item = _inventory.Fetch(id);
            if (item != null)
            {
                return item;
            }

            if (_location != null)
            {
                return _location.Locate(id);
            }

            return null;
        }

        public override string FullDescription
        {
            get
            {
                string result = "You are " + Name +
                                " the " + ShortDescription +
                                ". You are carrying:\n";

                if (_inventory.ItemList == string.Empty)
                {
                    result += "Nothing";
                }
                else
                {
                    result += _inventory.ItemList;
                }

                return result;
            }
        }
    }
}
