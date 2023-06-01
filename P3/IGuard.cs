using System;
namespace FighterClass
{
	public interface IGuard
	{
		void block(int x);
		void toggle_alive_status();

		bool alive_status();
    }
}

