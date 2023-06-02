using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace FighterClass
{
	public abstract class Guard : IGuard
	{
        protected int[] shieldArray;
		protected bool isAlive;
		protected bool shieldUpDown; // up if true || down if false
		protected int health;

        public Guard(int[] shieldStats)
		{
            if (shieldStats.Any(x => x < 0))
            {
                throw new ArgumentException("Shield stats cannot contain negative numbers.");
            }
            shieldArray = shieldStats;
			isAlive = true; // will start with alive
            shieldUpDown = true; // will start in "up" mode
			health = shieldStats.Length;
            ToggleAliveStatus();
		}

		public virtual void Block(int x)
		{
			if (x < 0 || x > shieldArray.Length)
			{
                throw new ArgumentException("Cannot Block a negative number. X IS INVALID");
            }

			RngUpDown();

			if (isAlive)
			{
                if (shieldUpDown && (shieldArray[x] >= 0)) // If shield is up, and the durability of the shield is greater than 0, it will block. Health will not decrease
                {
					shieldArray[x]--;
                }
				else if (shieldUpDown && (shieldArray[x] <= 0)) // If shield is up, but durability = 0, health will decrease
				{
					health--;
				}
				else if (!shieldUpDown) // Shield will be lost, and health will decrease
				{
					shieldArray[x] = 0; // loses shield
					health--;
				}
			}
            ToggleAliveStatus();
		}

		private void ToggleAliveStatus()
		{
			int viableShieldsInArray = shieldArray.Count(durability => durability > 0);
			if ((viableShieldsInArray >= shieldArray.Length / 2) && (health > 0))
			{
				isAlive = true;
			}
			else
			{
				isAlive = false;
			}
		}

		private void RngUpDown()
		{
			if ((shieldArray.Length + 3 * 9) % 2 == 0)
			{
				shieldUpDown = true;
			}
			else
			{
				shieldUpDown = false;
			}
		}

		public bool AliveStatus()
		{
			return isAlive;
		}

		
	}
}

