using System;
namespace FighterClass
{
	public class quirkyGuard : Guard
	{
		public quirkyGuard(int[] quirky_array):base(quirky_array){}

        public override void block(int x)
        {
			int ignored_number = arbitrarily_selected_shield(x);

            // Check if offset_x is within the bounds of the array
            if (ignored_number < 0 || ignored_number >= shield_array.Length)
            {
                throw new ArgumentException("Invalid, OUT OF BOUNDS.");
            }

            base.block(ignored_number);
        }

		private static int arbitrarily_selected_shield(int x)
		{
			int rng = (x * 2) % 3;

			return rng;
		}
    }
}

