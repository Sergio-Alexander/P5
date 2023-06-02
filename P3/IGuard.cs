using System;
namespace FighterClass
{
	public interface IGuard
	{
		void Block(int x);
		//void ToggleAliveStatus();

		bool AliveStatus();
    }
}

