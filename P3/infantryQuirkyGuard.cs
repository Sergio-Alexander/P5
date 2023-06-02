using System;
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

        public bool AliveStatus()
        {
            return guards.AliveStatus();
        }

    
    }
}

