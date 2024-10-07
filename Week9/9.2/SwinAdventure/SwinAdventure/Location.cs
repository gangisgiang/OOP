using System;
using System.Collections.Generic;
using SwinAdventure;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "You are at " + Name + ". " + ShortDescription + ".\n";
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public Path GetPath(string direction)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(direction))
                {
                    return path;
                }
            }
            return null;
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

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return (GameObject)path;
                }
            }

            return null;
        }
    }
}
