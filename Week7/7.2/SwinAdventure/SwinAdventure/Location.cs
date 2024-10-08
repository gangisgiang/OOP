using System;
namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private string _description;
        private string _name;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _name = name;
            _description = desc;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string ShortDescription
        {
            get
            {
                return _description;
            }
        }

        public string FullDescription
        {
            get
            {
                return "You are at " + _name + ". " + _description + ".\n";
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return _inventory.Fetch(id);
        }
    }
}