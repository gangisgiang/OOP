using System;
namespace SwinAdventure
{
	public abstract class GameObject : IdentifiableObject
	{
        public string _description;
        public string _name;

		public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
            foreach (string id in ids)
            {
                AddIdentifier(id);
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

        public virtual string FullDescription
        {
            get
            {
                return "This is a " + _description + ".";
            }
        }
	}
}

