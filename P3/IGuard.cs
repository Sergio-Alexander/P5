using System;
namespace FighterClass
{
	public interface IGuard
	{
		void block(int x);
		void update_alive_status();
		void rng_up_down();

		bool alive_status();
    }
}

