using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private Location _destination;
        public bool IsLocked { get; set; }
        public Path(string name, string desc, Location destination) : base(new string[] { "path" }, name, desc)
        {
            _destination = destination;
            IsLocked = false;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "This path leads to " + _destination.Name;
            }
        }
    }
}