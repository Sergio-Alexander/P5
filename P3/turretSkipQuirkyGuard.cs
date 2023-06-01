using System;
using System.Linq;

namespace FighterClass
{
    public class turretSkipQuirkyGuard : Turret, IGuard
    {
        protected int[] shield_array;
        protected bool is_alive;
        protected bool shield_up_down; // up if true || down if false
        private int unstable_k;

        public turretSkipQuirkyGuard(int[] arti, int armament_strength, int attack_range, int fighter_row, int fighter_col, int[] skip_quirky_array, int k) : base(arti, armament_strength, attack_range, fighter_row, fighter_col)
        {
            if (skip_quirky_array == null || skip_quirky_array.Length == 0)
            {
                throw new ArgumentException("Shield array cannot be null or empty.");
            }

            shield_array = skip_quirky_array;
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

            rng_up_down();

            if (is_alive)
            {
                int offset_x = x + unstable_k;
                int ignored_number = arbitrarily_selected_shield(x);

                // Ensure offset_x and ignored_number are different
                if (ignored_number == offset_x)
                {
                    ignored_number = (ignored_number + 1) % shield_array.Length;
                }

                // Check if offset_x and ignored_number are within the bounds of the array
                if (ignored_number < 0 || ignored_number >= shield_array.Length || offset_x < 0 || offset_x >= shield_array.Length)
                {
                    throw new ArgumentException("Invalid shield index after offset.");
                }
                else if (shield_up_down && (shield_array[ignored_number] >= 0) && (shield_array[offset_x] >= 0))
                {
                    shield_array[ignored_number]--;
                    shield_array[offset_x]--;
                }
                else if (!shield_up_down)
                {
                    shield_array[ignored_number] = 0; // loses shield
                    shield_array[offset_x] = 0;
                }

                update_alive_status();
            }
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
