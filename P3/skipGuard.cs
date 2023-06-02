using System;


/*
 -------------------- Class Invariants -----------------

unstableK is a non-negative integer that determines the offset for the Block method.

shieldArray is an array of non-negative integers representing the durability of each shield.

isAlive is a boolean representing the status of the guard.

shieldUpDown is a boolean representing the state of the shield (up if true, down if false).

health is a non-negative integer representing the health of the guard.
 
 */
namespace FighterClass
{
	public class SkipGuard : Guard
	{
        private readonly int unstableK;

        public SkipGuard(int[] skipArray, int k) : base(skipArray)
        {
            if (k < 0)
            {
                throw new ArgumentException("K is a negative number (INVALID)");
            }
            unstableK = k;
        }

        /*
        Preconditions:

        Block: The input x must be a non-negative integer.

        Postconditions:

        Block: The Block method will decrease the durability of the selected shield by 1 if the shield is up and has durability greater than 0. If the shield is up but has durability equal to 0, or if the shield is down, it will decrease the health of the guard by 1. It will also update the isAlive status of the guard. The selected shield is determined by the offset calculated using unstableK and x.

        */
        public override void Block(int x)
        {
            int offsetX = (x + unstableK) % shieldArray.Length; // This is done so that it would always be within the range of the array (no out of bounds)

            if (offsetX < 0 || offsetX > shieldArray.Length)
            {
                throw new ArgumentException("Cannot Block a negative number. X IS INVALID");
            }
          

            base.Block(offsetX);
        }
    }
}
/*
---------------------- Implementation Invariants ----------------

Block is an overridden method that calls the base Block method with a different index calculated by adding unstableK to the input x and taking the modulus with the length of shieldArray.

 */
