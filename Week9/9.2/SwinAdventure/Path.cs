using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private Location _destination;
        private string _direction;
        public bool IsLocked { get; set; }
        
        public Path(string[] ids, string name, string desc, Location destination, string direction) : base(ids, name, desc)
        {
            _destination = destination;
            _direction = direction;
            IsLocked = false;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public string Direction
        {
            get
            {
                return _direction;
            }
        }
    }
}