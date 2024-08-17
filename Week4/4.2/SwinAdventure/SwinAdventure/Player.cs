using System;
namespace SwinAdventure
{
	public class Player : GameObject
	{
        private Inventory _inventory;

		public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
        }
		{
		}
	}
}

