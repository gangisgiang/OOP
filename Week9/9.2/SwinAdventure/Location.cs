using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();
        private string _description;
        private string _name;

        public Location(string[] ids, string name, string desc) : base(ids)
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

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return _inventory.Fetch(id);       
        }

        public void Put(Path path)
        {
            _paths.Add(path);
        }
    }
}