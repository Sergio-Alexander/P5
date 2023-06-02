using System;

/*
 -------------------- Class Invariants -----------------

guards is an instance of QuirkyGuard that handles the blocking functionality.

omegaShield is a non-negative integer that accumulates with each block until it reaches armamentStrength.

omegaShieldThreshold is a non-negative integer equal to half of armamentStrength.

arti, armamentStrength, attackRange, fighterRow, and fighterCol are inherited from the Infantry class and follow the invariants defined in that class.
 
 */
namespace FighterClass
{
	public class InfantryQuirkyGuard:Infantry, IGuard
	{
        protected QuirkyGuard guards;

        protected int omegaShield;
        protected int omegaShieldThreshold;

        public InfantryQuirkyGuard(int[] arti, int armamentStrength, int attackRange, int fighterRow, int fighterCol, int[] quirkyArray) :base(arti, armamentStrength, attackRange, fighterRow, fighterCol)
		{
            if (quirkyArray == null || quirkyArray.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }

            guards = new QuirkyGuard(quirkyArray);

            omegaShield = 0;
            omegaShieldThreshold = armamentStrength / 2;
        }

        /*
        Preconditions:

        Block: The input x must be a non-negative integer.

        Postconditions:

        Block: If omegaShield is less than armamentStrength, it increases omegaShield by 1, calls the Block method on guards with x, moves the infantry, and targets an object. If omegaShield is equal to or greater than armamentStrength, it resets omegaShield to 0 and returns.
        AliveStatus: Returns the alive status of guards. 
        */

        public virtual void Block(int x)
        {
            omegaShield++;

            if (omegaShield >= armamentStrength) // Once this guard has enough omegaShield, it will block incoming attack instead of damaging the durability of the shield
            {
                omegaShield = 0;
                return;
            }
            guards.Block(x);
            Move(row + 1, column + 1);
            Target(row + 2, column + 2, armamentStrength - 2); // once blocked, it will target the object 
        }

        /*
        Preconditions:

        AliveStatus: none

        Postconditions:

        Returns the status of the object, if it is alive or not 
        */

        public bool AliveStatus()
        {
            return guards.AliveStatus();
        }

    
    }
}
/*
---------------------- Implementation Invariants ----------------
Block is a method that increases omegaShield with each call. If omegaShield reaches armamentStrength, it resets omegaShield to 0 and returns. Otherwise, it calls the Block method on guards, moves the infantry, and targets an object.

AliveStatus is a method that returns the alive status of guards.
 */
