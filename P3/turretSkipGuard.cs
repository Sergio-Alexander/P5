using System;
namespace FighterClass
{
	public class TurretSkipGuard : Turret, IGuard
	{
        protected SkipGuard guards;

        protected int omegaShield;
        protected int omegaShieldThreshold;


        public TurretSkipGuard(int[] arti, int armamentStrength, int attack_range, int fighter_row, int fighter_col, int[] skipGuardArray, int k) : base(arti, armamentStrength, attack_range, fighter_row, fighter_col)
        {
            if (skipGuardArray == null || skipGuardArray.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }

            guards = new SkipGuard(skipGuardArray, k);
            omegaShield = 0;
            omegaShieldThreshold = armamentStrength / 2;
        }

        public void Block(int x)
        {
            omegaShield++;

            if (omegaShield >= armamentStrength) // Once this guard has enough omegaShield, it will Block incoming attack instead of damaging the durability of the shield
            {
                omegaShield = 0;
                return;
            }
            guards.Block(x);
            Target(row + 2, column + 2, armamentStrength - 2); // once Blocked, it will target the object 
        }
        public bool AliveStatus()
        {
            return guards.AliveStatus();
        }

    
    }
}

