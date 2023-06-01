using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace FighterClass
{
	public abstract class Guard : IGuard
	{
        protected int[] shield_array;
		protected bool is_alive;
		protected bool shield_up_down; // up if true || down if false

        public Guard(int[] shield_stats)
		{
			shield_array = shield_stats;
			is_alive = true; // will start with alive
            shield_up_down = true; // will start in "up" mode
			update_alive_status();
		}

		public virtual void block(int x)
		{
			if (x < 0 || x > shield_array.Length)
			{
                throw new ArgumentException("Cannot block a negative number. X IS INVALID");
            }

			rng_up_down();

			if (is_alive)
			{
                if (shield_up_down && (shield_array[x] >= 0))
                {
					shield_array[x]--;
                } else if (!shield_up_down)
				{
					shield_array[x] = 0; // loses shield
				}
			}

			update_alive_status();
		}

		public void update_alive_status()
		{
			int viable_shields_in_array = shield_array.Count(durability => durability > 0);
			if (viable_shields_in_array >= shield_array.Length / 2)
			{
				is_alive = true;
			}
			else
			{
				is_alive = false;
			}
		}

		public void rng_up_down()
		{
			if ((shield_array.Length + 3 * 9) % 2 == 0)
			{
				shield_up_down = true;
			}
			else
			{
				shield_up_down = false;
			}
		}

		public bool alive_status()
		{
			return is_alive;
		}
	}
}

