using System;
namespace FighterClass
{
	public class skipQuirkyGuard : Guard
	{
        private int unstable_k;

        public skipQuirkyGuard(int[] skip_quirky_array, int k):base(skip_quirky_array)
		{
			unstable_k = k;
		}

        public override void block(int x)
        {
            int ignored_number = arbitrarily_selected_shield(x);
            int offset_x = (x + unstable_k) % shield_array.Length;

            if (ignored_number < 0 || ignored_number >= shield_array.Length || offset_x < 0 || offset_x >= shield_array.Length)
            {
                throw new ArgumentException("Invalid, OUT OF BOUNDS");
            }

            base.block(ignored_number);
            base.block(offset_x);
        }

        private static int arbitrarily_selected_shield(int x)
        {
            int rng = (x * 2) % 3;

            return rng;
        }
    }
}

