using System;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private Location _destination;

        public Path(string[] ids, string desc, Location destination) : base(ids)
        {
            _destination = destination;
            Description = desc;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public string Description
        {
            get;
        }
    }
}
