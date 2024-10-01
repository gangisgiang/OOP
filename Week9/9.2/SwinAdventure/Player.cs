using System;
namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
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
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
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
                result += _inventory.ItemList;
                return result;
            }
        }
    }
}

