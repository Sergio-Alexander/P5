using System;
namespace FighterClass
{
	public class turretQuirkyGuard : Turret, IGuard
	{
        protected int[] shield_array;
        protected bool is_alive;
        protected bool shield_up_down; // up if true || down if false

        public turretQuirkyGuard(int[] arti, int armament_strength, int attack_range, int fighter_row, int fighter_col, int[] quirky_array) :base(arti, armament_strength, attack_range, fighter_row, fighter_col)
		{
            if (quirky_array == null || quirky_array.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }

            shield_array = quirky_array;
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

            int ignored_number = arbitrarily_selected_shield(x);

            rng_up_down();

            if (is_alive)
            {
                if (shield_up_down && (shield_array[ignored_number] >= 0))
                {
                    shield_array[ignored_number]--;
                }
                else if (!shield_up_down)
                {
                    shield_array[ignored_number] = 0; // loses shield
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


        private static int arbitrarily_selected_shield(int x)
        {
            int rng = (x * 2) % 3;

            return rng;
        }
    }
}

