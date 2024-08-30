using System;
namespace SwinAdventure
{
	public class Item : GameObject
	{
		public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _name = name;
            _description = desc;
            foreach (string id in idents)
            {
                AddIdentifier(id);
            }
        }
	}
}

