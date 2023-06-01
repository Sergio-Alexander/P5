using System;
namespace FighterClass
{
	public class skipGuard : Guard
	{
        private int unstable_k;

        public skipGuard(int[] skip_array, int k) : base(skip_array)
        {
            unstable_k = k;
        }


        public override void block(int x)
        {
            int offset_x = x + unstable_k;

            // Check if offset_x is within the bounds of the array
            if (offset_x < 0 || offset_x >= shield_array.Length)
            {
                throw new ArgumentException("Invalid shield index after offset.");
            }

            base.block(offset_x);
        }
    }
}

