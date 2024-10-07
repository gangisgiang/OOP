using System;
namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
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
                return "This is " + _description;
            }
        }

        public static explicit operator GameObject(Path v)
        {
            throw new NotImplementedException();
        }
    }
}

