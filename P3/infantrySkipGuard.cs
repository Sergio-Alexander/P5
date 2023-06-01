using System;
namespace FighterClass
{
	public class infantrySkipGuard: Infantry, IGuard
	{

        protected int[] shield_array;
        protected bool is_alive;
        protected bool shield_up_down; // up if true || down if false

        private int unstable_k;

        public infantrySkipGuard(int[] arti, int armament_strength, int attack_range, int fighter_row, int fighter_col, int[] skip_guard_array, int k) :base(arti, armament_strength, attack_range, fighter_row, fighter_col)
		{


            if (skip_guard_array == null || skip_guard_array.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }

            shield_array = skip_guard_array;
            is_alive = true; // will start with alive
            shield_up_down = true; // will start in "up" mode

            unstable_k = k;

            update_alive_status();


        }

        public void block(int x)
        {
            if (x < 0 || x > shield_array.Length)
            {
                throw new ArgumentException("Cannot block a negative number. X IS INVALID");
            }

            int offset_x = x + unstable_k;

            // Check if offset_x is within the bounds of the array
            if (offset_x < 0 || offset_x >= shield_array.Length)
            {
                throw new ArgumentException("Invalid shield index after offset.");
            }

            rng_up_down();

            if (is_alive)
            {
                if (shield_up_down && (shield_array[offset_x] >= 0))
                {
                    shield_array[offset_x]--;
                }
                else if (!shield_up_down)
                {
                    shield_array[offset_x] = 0; // loses shield
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
    }
}

