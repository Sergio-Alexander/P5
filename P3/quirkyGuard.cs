using System;
namespace FighterClass
{
	public class quirkyGuard : Guard
	{
		public quirkyGuard(int[] quirky_array):base(quirky_array)
		{
		}

        public override void block(int x)
        {
			int ignored_number = arbitrarily_selected_shield(x);

            base.block(ignored_number);
        }

		private static int arbitrarily_selected_shield(int x)
		{
			int rng = (x * 2) % 3;

			return rng;
		}
    }
}

