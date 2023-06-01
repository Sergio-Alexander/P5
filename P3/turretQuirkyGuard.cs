using System;
namespace FighterClass
{
	public class turretQuirkyGuard : Turret, IGuard
	{
        protected quirkyGuard guards;
      
        protected int omega_shield;
        protected int omega_shield_threshold;

        public turretQuirkyGuard(int[] arti, int armament_strength, int attack_range, int fighter_row, int fighter_col, int[] quirky_array) :base(arti, armament_strength, attack_range, fighter_row, fighter_col)
		{
            if (quirky_array == null || quirky_array.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }
            
            guards = new quirkyGuard(quirky_array);
            omega_shield = 0;
            omega_shield_threshold = armament_strength / 2;
        }

        public void block(int x)
        {
            omega_shield++;

            if (omega_shield >= armament_strength) // Once this guard has enough omega_shield, it will block incoming attack instead of damaging the durability of the shield
            {
                omega_shield = 0;
                return;
            }
            guards.block(x);
            Target(row + 2, column + 2, armament_strength - 2); // once blocked, it will target the object in front of it
        }

        public void toggle_alive_status()
        {
            guards.toggle_alive_status();
        }

        //public void rng_up_down()
        //{
        //    guards.rng_up_down();
        //}

        public bool alive_status()
        {
            return guards.alive_status();
        }
    }
}

