using System;
namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

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

        public Location Location { get; set; }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            if (_inventory.Fetch(id) != null) 
            {
                return _inventory.Fetch(id);
            }

            if (Location.Locate(id) != null)
            {
                return Location.Locate(id);
            }
        }

        public void Move(Path path)
        {
            Location = path.Destination;
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