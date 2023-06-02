using System;


/*
 -------------------- Class Invariants -----------------

counter is always non-negative and increments by 1 after each call to Block.

shieldArray is an array of non-negative integers representing the durability of each shield.

isAlive is a boolean representing the status of the guard.

shieldUpDown is a boolean representing the state of the shield (up if true, down if false).

health is a non-negative integer representing the health of the guard.
 
 */


namespace FighterClass
{
	public class QuirkyGuard : Guard
	{
        private int counter;
		public QuirkyGuard(int[] quirkyArray):base(quirkyArray)
        {
            counter = 0;
        }

        /*
        Preconditions:

        The input x must be a non-negative integer less than the length of shieldArray

        Postconditions:

        The Block method will decrease the durability of the selected shield by 1 if the shield is up and has durability greater than 0. If the shield is up but has durability equal to 0, or if the shield is down, it will decrease the health of the guard by 1. It will also update the isAlive status of the guard.

        */

        public override void Block(int x)
        {

            int ignoredNumber = ArbitrarilySelectedShield(x);


            // Check if offset_x is within the bounds of the array
            if (ignoredNumber < 0 || ignoredNumber >= shieldArray.Length)
            {
                throw new ArgumentException("Invalid, OUT OF BOUNDS.");
            }

            base.Block(ignoredNumber);
        }

        /*
        Preconditions:

        The input x must be a non-negative integer.

        Postconditions:

        The ArbitrarilySelectedShield method will return an index within the bounds of shieldArray. It will also increment counter by 1.

        */

        private int ArbitrarilySelectedShield(int x)
		{
            return (counter++ + x) % shieldArray.Length;
        }
    }
}


/*
---------------------- Implementation Invariants ----------------

ArbitrarilySelectedShield is a private method that calculates the index of the shield to be used in the Block method. It uses the counter and the input x to calculate the index, and it increments the counter after each call.

Block is an overridden method that calls the base Block method with a different index calculated by ArbitrarilySelectedShield.

 */
