using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

/*
 -------------------- Class Invariants -----------------

shieldArray must always contain non-negative integers.

isAlive is true if the guard is alive, and false if the guard is dead.

shieldUpDown is true if the shield is up, and false if the shield is down.

health must always be a non-negative integer.


Notes: Here the class Guard is being being inherited by IGuard. The Guard class is essentially the base for all the guard classes, this class includes the base Block, and Construction. 
 
 */

namespace FighterClass
{

    /*
	Preconditions:

	shieldStats must not be null.
	shieldStats must not contain any negative numbers.

	Postconditions:

	shieldArray is initialized with the values from shieldStats.
	isAlive is set to true.
	shieldUpDown is set to true.
	health is set to the length of shieldArray.
	ToggleAliveStatus is called.
	 */
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
			health = shieldArray.Length;
            ToggleAliveStatus();
		}

        /*
		Preconditions:

		x must be a non-negative integer.
		x must be less than the length of shieldArray.

		Postconditions:

		If shieldUpDown is true and shieldArray[x] is greater than or equal to 0, shieldArray[x] is decremented by 1.
		If shieldUpDown is true and shieldArray[x] is less than or equal to 0, health is decremented by 1.
		If shieldUpDown is false, shieldArray[x] is set to 0 and health is decremented by 1.
		ToggleAliveStatus is called.
	
		 */

        public virtual void Block(int x)
		{
			if (x < 0 || x > shieldArray.Length)
			{
                throw new ArgumentException("Cannot Block a negative number. X IS INVALID");
            }

			RngUpDown(); // Randomly decides whether or not it this object will be either up or down when blocking

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

        /*
		Preconditions:

		None.

		Postconditions:

		If the number of elements in shieldArray that are greater than 0 is greater than or equal to half the length of shieldArray, and health is greater than 0, isAlive is set to true.
		Otherwise, isAlive is set to false.
		 */

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


        /*
		Preconditions:

		None.

		Postconditions:

		If the health is even, shieldUpDown is set to true which means UP
		Otherwise, shieldUpDown is set to false which means DOWN
		 
		 */

        private void RngUpDown()
		{
			if (health % 2 == 0)
			{
				shieldUpDown = true;
			}
			else
			{
				shieldUpDown = false;
			}
		}


        /*
         
        Preconditions:

		None.
		Postconditions:

		Returns the current value of isAlive.
		
         */

        public bool AliveStatus()
		{
			return isAlive;
		}

		
	}
}


/*
---------------------- Implementation Invariants ----------------

shieldArray is never null and does not contain negative values: Once the Guard object is created, the shieldArray should always point to a valid array object and its elements should always be non-negative. This is ensured by the constructor and the Block method.

health is always non-negative: The health of the Guard should never fall below zero. This is ensured by the constructor and the Block method.

isAlive reflects the current state of the Guard: The isAlive flag should accurately represent whether the Guard is alive or not based on the current state of the shieldArray and health. This is ensured by the ToggleAliveStatus method which is called after every block operation.

shieldUpDown is always a valid boolean value: The shieldUpDown flag should always be either true or false. This is ensured by the RngUpDown method.

The Block method always leaves the Guard in a valid state: After a call to Block, the Guard's state should still be consistent with its invariants. This is ensured by the Block method itself and the methods it calls (RngUpDown and ToggleAliveStatus).

 */

