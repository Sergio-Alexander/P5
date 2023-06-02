using System;


/*
 -------------------- Class Invariants -----------------

guards is an instance of QuirkyGuard and is never null.
omegaShield is a non-negative integer.
omegaShieldThreshold is a non-negative integer and is half of armamentStrength.
 
 */
namespace FighterClass
{
	public class TurretQuirkyGuard : Turret, IGuard
	{
        protected QuirkyGuard guards;

        protected int omegaShield;
        protected int omegaShieldThreshold;

        public TurretQuirkyGuard(int[] arti, int armamentStrength, int attackRange, int fighterRow, int fighterCol, int[] quirkyArray) : base(arti, armamentStrength, attackRange, fighterRow, fighterCol)
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

        x is a non-negative integer.

        Postconditions:

        If omegaShield is greater than or equal to armamentStrength, omegaShield is reset to 0 and the method returns without calling guards.Block(x).
        If omegaShield is less than armamentStrength, guards.Block(x) is called and omegaShield is incremented by 1.
        The guard targets a new position by calling Target(row + 2, column + 2, armamentStrength - 2).
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
            Target(row + 2, column + 2, armamentStrength - 2); // once blocked, it will target the object 
        }

        /*
        Preconditions:

        None.
        Postconditions:

        Returns the alive status of the guard by calling guards.AliveStatus().
         */

        public bool AliveStatus()
        {
            return guards.AliveStatus();
        }
    }
}
/*
---------------------- Implementation Invariants ----------------
guards is used to handle the blocking of attacks.
omegaShield is used to track the number of times the guard has blocked an attack.
omegaShieldThreshold is the limit that omegaShield needs to reach before it can block an attack without damaging the durability of the shield.
 */
