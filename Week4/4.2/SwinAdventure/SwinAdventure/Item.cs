using System;
namespace SwinAdventure
{
	public class Item : GameObject
	{
		public Item(string[] idents, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
            foreach (string id in ids)
            {
                AddIdentifier(id);
            }
        }
	}
}

